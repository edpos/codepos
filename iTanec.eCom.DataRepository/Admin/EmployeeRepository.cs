using iTanec.eCom.BusinessObjects.Model.Admin;
using iTanec.eCom.BusinessObjects.ViewModel.Admin;
using iTanec.eCom.Services.DataManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTanec.eCom.DataRepository.Admin
{
    public class EmployeeRepository : BaseRepository<EmployeeRepository>
    {
        public UserListVM GetEmployeeList(int userId)
        {
            UserListVM user = new UserListVM();
            DataSet dataSet = null;
            try
            {
                IList<IDataParameter> list = new List<IDataParameter>();
                list.Add(PoSDBUtils.CreateParameter("user_id", PoSDBUtils.ConvertInvalidSeqIDsToDBNull(userId)));

                dataSet = ProductDB.DBInstance.ExecuteDataSet("sProc_Pos_Admin_GetUserList", list);

                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    user.userList = dataSet.Tables[0].AsEnumerable().Select(x => new UserListModel
                    {
                        UserId = (int)(x["user_id"]),
                        UserCode = (string)(x["user_code"]),
                        FirstName = (string)(x["first_name"]),
                        LastName = (string)(x["last_name"]),
                        LastLoginTime = (DateTime)(x["last_login_time"]),
                        PrefixId = (int)(x["prefix_id"])
                    }).ToList();
                }
            }
            catch (SqlException ex)
            {
                //ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
                //i = 1;
            }
            catch (Exception e)
            {
                // ProductLogManager.DebugWrite(e.Message);
            }
            return user;
        }
    }
}
