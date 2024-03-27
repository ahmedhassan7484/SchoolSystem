using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.IReposotory
{
    public interface IGenaricReposotory<T> where T : class
    {
        T FindWithCriteria(Expression<Func<T,bool>> Criteria, string[] includes=null);
        public T FindById(int id);
        public List<T> FindAllWithCriteria(Expression<Func<T, bool>> Criteria, string[] includes = null);
        public List<T> FindAllWithOutCriteria(string[] includes = null);
        void Add(T t);
        void Remove(T t);
        void Update(T t);

    }
}
