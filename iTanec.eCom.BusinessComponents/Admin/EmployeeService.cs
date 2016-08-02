using iTanec.eCom.BusinessObjects.ViewModel.Admin;
using iTanec.eCom.DataRepository.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTanec.eCom.BusinessComponents.Admin
{
    public class EmployeeService : IEmployeeService
    {
        public UserVM GetEmployee(int EmpId)
        {
            return EmployeeRepository.GetInstance().GetEmployee(EmpId);
        }
    }
}
