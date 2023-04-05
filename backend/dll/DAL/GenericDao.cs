using dll.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.DAL
{
    public enum OperationType
    {
        Detached = 0,
        Unchanged = 1,
        Deleted = 2,
        Modified = 3,
        Added = 4
    }

    public abstract class GenericDao<T> where T: class
    {
        public CareerMapContext Context { get; set; }
        public GenericDao(CareerMapContext context)
        {
            this.Context = context;
        }

        public void Execute(T item, OperationType type)
        {
            Context.Entry<T>(item).State = (EntityState)type;
            Context.SaveChanges();
        }

        public IEnumerable<T> List()
        {
            return Context.Set<T>().ToList();
        }

        public T? FindById(int id)
        {
            return Context.Set<T>().Find();
        }
    }
}
