using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.DAL.Infracstructure
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T Update(int id,T entity);
      
        void Delete (int id);
        T GetById(int id);

        List<T> List();
    }
}
