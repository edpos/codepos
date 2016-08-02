using iTanec.eCom.BusinessObjects.ViewModel.Admin;

namespace iTanec.eCom.BusinessComponents.Admin
{
    public interface IEmployeeService
    {
        UserVM GetEmployee(int EmpId);
    }
}
