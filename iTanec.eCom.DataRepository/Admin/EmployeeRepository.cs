using iTanec.eCom.BusinessObjects.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTanec.eCom.DataRepository.Admin
{
    public class EmployeeRepository : BaseRepository<EmployeeRepository>
    {
        public UserVM GetEmployee(int EmpId)
        {
            UserVM user = new UserVM();
            return user;
        }
    }
}
