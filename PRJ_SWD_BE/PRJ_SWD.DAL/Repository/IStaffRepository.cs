using PRJ_SWD.Application.ViewModel;

namespace PRJ_SWD.DAL.Repository
{
    public interface IStaffRepository
    {
        List<StaffViewModel> List();
    }
}