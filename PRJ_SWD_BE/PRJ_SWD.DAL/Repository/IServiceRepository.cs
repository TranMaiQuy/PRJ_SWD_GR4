using PRJ_SWD.DAL.Models;
using PRJ_SWD.Application.ViewModel;

namespace PRJ_SWD.DAL.Repository
{
    public interface IServiceRepository
    {
        List<ServiceViewModel> List();
        Service GetById(int id);
        void Delete(int id);
        void Add(Service entity);
        Service Update(int id, Service entity);
    }
}