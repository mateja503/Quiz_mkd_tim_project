using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Repository.Interface
{
    public interface IRepository <T> where T : class 
    {
        Task<List<T>> GetAll ();

        Task<T?> Get(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);//check if i need the upate one for the repository ?
    }
}
