using Quiz.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Repository.Interface
{
    public interface IUnitOfWork
    {
        
        IAnswerRepository Answer { get; }
        IEvent_UserRepository Event_User{ get; }
        IEventRepository Event { get; }
        IQuestionRepository Question { get; }
        IQuizRepository Quiz { get; }
        ITypeQuizRepository TypeQuiz{ get; }

        void Save();

    }
}
