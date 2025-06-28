using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.Models;

namespace PRJ_SWD.DAL.Infracstructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private PrjSwdContext context;
        public UnitOfWork(PrjSwdContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
