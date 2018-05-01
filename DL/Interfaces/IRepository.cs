using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itc.Am.Common.Models;

namespace Itc.Am.DL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        //Get an entity by id
        T GetById(int id);

        //Get all entities of type T
        IEnumerable<T> GetAll();

        void Update(T entity);
    }
}
