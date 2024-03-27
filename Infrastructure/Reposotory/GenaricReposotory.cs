

using Application.IReposotory;
using Application.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Reposotory
{
    public class GenaricReposotory<T> : IGenaricReposotory<T> where T : class
    {
        private readonly SchoolSystemContext _context;
        public GenaricReposotory(SchoolSystemContext context)
        {
            _context = context;
            
        }
        public void Add(T t)
        {
            _context.Add(t);
          //  _context.SaveChanges();
        }

        public List<T> FindAllWithCriteria(Expression<Func<T,bool>> Criteria, string[] includes=null)
        {
            IQueryable<T>Query=_context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    Query=Query.Include(item);
                }

            }
           return Query.Where(Criteria).ToList();
        }
        public List<T> FindAllWithOutCriteria( string[] includes=null)
        {
            IQueryable<T>Query=_context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    Query=Query.Include(item);
                }

            }
           return Query.ToList();
        }

        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T FindWithCriteria(Expression<Func<T, bool>> Criteria, string[] includes = null)
        {
            IQueryable<T> Query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    Query = Query.Include(item);
                }

            }
            return Query.Where(Criteria).FirstOrDefault();
        }

        public void Remove(T t)
        {
           _context.Remove(t);
         //   _context.SaveChanges(); 
        }

        public void Update(T t)
        {
            _context.Entry(t).State = EntityState.Modified;
            //_context.SaveChanges();
        }
    }
}
