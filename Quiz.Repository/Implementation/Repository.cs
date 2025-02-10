using Microsoft.EntityFrameworkCore;
using Quiz.Repository.Data;
using Quiz.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            _db.Answers.Include(u => u.Question).Include(u => u.QuestionId);
            _db.Events.Include(u => u.Quiz).Include(u=>u.QuizId);
            _db.Questions.Include(u=>u.Quiz).Include(u => u.QuizId);
            _db.Quizes.Include(u=>u.TypeQuize).Include(u => u.TypeQuizeId)
                .Include(u=>u.Event).Include(u=> u.QuestionList);
            _db.TypeQuizes.Include(u => u.QuizList);
            //_db.TypeQuizes.Include(u => u.Quiz);
        }


        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

       

        public T? Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties)) 
            {
                foreach (var includeProperty 
                    in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();
        }

       
        public IEnumerable<T?> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties)) 
            {
                foreach (var includeProperty in
                 includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) 
                {
                   query =  query.Include(includeProperty);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
