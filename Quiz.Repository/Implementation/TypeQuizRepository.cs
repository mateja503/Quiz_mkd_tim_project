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
    public class TypeQuizRepository : Repository<TypeQuiz>, ITypeQuizRepository
    {
        private readonly ApplicationDbContext _db;
        public TypeQuizRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TypeQuiz typeQuiz)
        {
            _db.TypeQuizes.Update(typeQuiz);
        }
    }
}
