using Quiz.Domain.Domain_Models;
using Quiz.Repository.Data;
using Quiz.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _db;
        public IAnswerRepository Answer { get; private set; }

        public IEvent_UserRepository Event_User { get; private set; }

        public IEventRepository Event { get; private set; }

        public IQuestionRepository Question { get; private set; }

        public IQuizRepository Quiz { get; private set; }

        public ITypeQuizRepository TypeQuiz { get; private set; }

       

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Answer = new AnswerRepository(_db);
            Event_User = new Event_UserRepository(_db);
            Event = new EventRepository(_db);
            Question = new QuestionRepository(_db);
            Quiz = new QuizRepository(_db);
            TypeQuiz = new TypeQuizRepository(_db);

        }



        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
