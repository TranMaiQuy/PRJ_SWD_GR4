using PRJ_SWD.Application.ViewModel;
using PRJ_SWD.DAL.Models;

namespace PRJ_SWD.DAL.Repository
{
    public interface IStaffRepository
    {
        List<Account> List();
    }
}