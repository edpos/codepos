using iTanec.eCom.BusinessObjects.ViewModel.Admin;

namespace iTanec.eCom.BusinessComponents.Admin
{
    public interface IEmployeeService
    {
        UserListVM GetEmployee(int EmpId);
    }
}
