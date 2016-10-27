using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTanec.eCom.BusinessObjects.Model.Admin
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {
            EmployeeID = 1001;
            FirstName = "Dig";
            LastName = "Vijay";
            DateOfBirth = new DateTime();
        }
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

}
