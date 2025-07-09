using PRJ_SWD.DAL.Models;
using PRJ_SWD.Application.ViewModel;

namespace PRJ_SWD.DAL.Repository
{
    public interface IServiceRepository
    {
        void Add(Service service);
        void Delete(int id);
        Service? GetById(int id);
        List<Service> GetAll();
        Service Update(Service service);
        Account? GetManager(int managerId);
    }
}