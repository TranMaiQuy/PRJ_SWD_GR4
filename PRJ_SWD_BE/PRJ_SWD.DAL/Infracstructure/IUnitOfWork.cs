using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ_SWD.DAL.Infracstructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
