using Microsoft.AspNetCore.Mvc;
using Quiz.Domain.ViewModels;
using Quiz.Repository.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz.Domain.Domain_Models;
using ExcelDataReader;
namespace Quiz.Web.Controllers
{
    public class QuizController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuizController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var items = _unitOfWork.Quiz.GetAll(includeProperties: "TypeQuize,QuestionList,Event");
            return View(items);
        }

        public IActionResult Create() 
        {
            QuizVM quizVM = new()
            {
                Quiz = new Domain.Domain_Models.Quiz(),
                TypeQuizList = _unitOfWork.TypeQuiz.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Type,
                    Value = u.Id.ToString()
                }),
                EventList = _unitOfWork.Event.GetAll(includeProperties: "Quiz").Where(u => u.Quiz == null)
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                QuestionList = new List<Question>()
            };
            return View(quizVM);
            
        }

        [HttpPost]
        public IActionResult Create(QuizVM quizVM)
        {
            if (ModelState.IsValid) 
            {
                _unitOfWork.Quiz.Add(quizVM.Quiz);
                _unitOfWork.Save();
                quizVM.TypeQuizList = _unitOfWork.TypeQuiz.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Type,
                    Value = u.Id.ToString()
                });
                quizVM.EventList = _unitOfWork.Event.GetAll(includeProperties: "Quiz").Where(u => u.Quiz == null)
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                quizVM.QuestionList = new List<Question>();
                return View(quizVM);

            }

            QuizVM vm = new()
            {
                Quiz = new Domain.Domain_Models.Quiz(),
                TypeQuizList = _unitOfWork.TypeQuiz.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Type,
                    Value = u.Id.ToString()
                }),
                EventList = _unitOfWork.Event.GetAll(includeProperties: "Quiz").Where(u => u.Quiz == null)
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                QuestionList = new List<Question>()
            };
            return View(vm);

        }

        public IActionResult Delete(int? id) 
        {
            var quiz = _unitOfWork.Quiz.Get(u => u.Id == id, includeProperties: "TypeQuize,Event");
            
            return View(quiz);
        }

        [ActionName("Delete")]
        [HttpPost]
        public IActionResult DeleteDB(int? id)
        {
            if (id == 0 && id == null) 
            {
                return NotFound();
            }
            var quiz = _unitOfWork.Quiz.Get(u => u.Id == id, includeProperties: "TypeQuize,Event");

            if (quiz == null) 
            {
                return NotFound();
            }
            if (quiz.FileName != null) 
            {
                // Delete the associated Excel file
                var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");
                var fileName = quiz.FileName; // Assuming the file name is based on the quiz ID
                var filePath = Path.Combine(uploadDirectory, fileName);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
           
            _unitOfWork.Quiz.Remove(quiz);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Quiz");
        }

        public IActionResult Edit(int? id) 
        {
            if (id == 0 || id == null) 
            {
                return NotFound();
            }
            var quiz = _unitOfWork.Quiz.Get(u => u.Id == id, includeProperties: "TypeQuize,QuestionList,Event");

            if (quiz == null) 
            {
                return NotFound();
            }

            QuizVM quizVM = new()
            {
                Quiz = quiz,
                TypeQuizList = _unitOfWork.TypeQuiz.GetAll().Select(u => new SelectListItem
                {
                    Text = u?.Type,
                    Value = u.Id.ToString()
                }),
                EventList = _unitOfWork.Event.GetAll(includeProperties: "Quiz").Where(u => u.Quiz == null)
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                QuestionList = new List<Question>()
            };
            return View(quizVM);

            
        }

        [HttpPost]
        public IActionResult Edit(QuizVM quizVM)
        {
            if (quizVM.Quiz == null) 
            {
                return NotFound();
            }

            if (ModelState.IsValid) 
            {
                _unitOfWork.Quiz.Update(quizVM.Quiz);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Quiz");
            
            }


            quizVM.TypeQuizList = _unitOfWork.TypeQuiz.GetAll().Select(u => new SelectListItem
            {
                Text = u?.Type,
                Value = u.Id.ToString()
            });

            quizVM.EventList = _unitOfWork.Event.GetAll(includeProperties: "Quiz").Where(u => u.Quiz == null)
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            return View(quizVM);


        }

        public IActionResult Detail(int? quizId)
        {
            var item = _unitOfWork.Quiz.Get(u => u.Id == quizId, includeProperties: "TypeQuize,Event,QuestionList");
            if (item == null)
            {
                return NotFound();
            }

            QuizVM quizVM = new()
            {
                Quiz = item,
                TypeQuizList = _unitOfWork.TypeQuiz.GetAll(includeProperties: "QuizList").Where(u => u.Id == item.TypeQuizeId)
                .Select(u => new SelectListItem
                {
                    Text = u.Type,
                    Value = u.Id.ToString()
                }),
                EventList = _unitOfWork.Event.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),

                QuestionList = _unitOfWork.Question.GetAll(includeProperties: "Quiz,Answers")
                .Where(u => u.QuizId == item.Id)


            };
            return View(quizVM);
        }

        public IActionResult ExcelFileReader(int? quizId) 
        {
            var item = _unitOfWork.Quiz.Get(u => u.Id == quizId);
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> ExcelFileReader(IFormFile file, int quizId)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //Upload File
            if (file != null && file.Length > 0) 
            {
                
                var uploadDirectory = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Uploads";

                if (!Directory.Exists(uploadDirectory)) 
                { 
                    Directory.CreateDirectory(uploadDirectory);
                }

                var filePath = Path.Combine(uploadDirectory, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create)) 
                {
                    await file.CopyToAsync(stream);
                }

                var quiz = _unitOfWork.Quiz.Get(u => u.Id == quizId);
                if (quiz != null) 
                {
                    quiz.FileName = file.FileName;
                    _unitOfWork.Quiz.Update(quiz);
                    _unitOfWork.Save();

                }

                //Read File
                using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    var excelData = new List<List<object>>();
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                       
                       
                        do
                        {
                            bool isHeaderSkipped = false;
                            while (reader.Read())
                            {
                                var rowData = new List<object>();
                                for (int column = 0; column < reader.FieldCount; column++)
                                {
                                    rowData.Add(reader.GetValue(column));
                                }
                                excelData.Add(rowData);

                                if (!isHeaderSkipped) 
                                {
                                    isHeaderSkipped = true;
                                    continue;
                                }

                                Question question = new Question();
                                question.Text = reader.GetValue(0).ToString();
                                question.Answers = new List<Answer>();
                                question.QuizId = quizId;
                                _unitOfWork.Question.Add(question);
                                _unitOfWork.Save();
                                var q = _unitOfWork.Question.Get(u => u == question);
                                var correctAnswer = reader.GetValue(5).ToString();
                                if (q != null)
                                {
                                    for (int i = 1; i <= 4; i++)
                                    {
                                        Answer answer = new Answer();
                                        answer.QuestionId = q.Id;
                                        answer.Text = reader.GetValue(i).ToString();
                                        if (correctAnswer == answer.Text)
                                        {
                                            answer.isCorrect = true;
                                        }
                                        else 
                                        {
                                            answer.isCorrect = false;
                                        }
                                        _unitOfWork.Answer.Add(answer);
                                        _unitOfWork.Save();
                                        q?.Answers?.Add(answer);
                                        _unitOfWork.Question.Update(q);
                                        _unitOfWork.Save();
                                    }
                                }

                            }
                        } while (reader.NextResult());

                        ViewBag.ExcelData = excelData;
                       
                    }
                }

           
            }
            return View();
        }



    }
}
