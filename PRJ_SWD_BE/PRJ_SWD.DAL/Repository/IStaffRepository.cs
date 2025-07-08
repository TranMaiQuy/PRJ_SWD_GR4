using PRJ_SWD.DAL.ViewModel;

namespace PRJ_SWD.DAL.Repository
{
    public interface IStaffRepository
    {
        List<StaffViewModel> List();
    }
}