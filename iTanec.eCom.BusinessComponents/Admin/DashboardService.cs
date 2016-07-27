using iTanec.eCom.DataRepository.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTanec.eCom.BusinessComponents.Admin
{
    public class DashboardService : IDashboardService
    {
        public string GetDashBoradManagementDetails()
        {
            return DashboardRepository.GetInstance().GetDashboardDataObject();
        }
    }
}
