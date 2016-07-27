using UIG.Accounting.BusinessObjects;
using UIG.Accounting.CrosscuttingServices.DataManagement;
using UIG.Accounting.CrosscuttingServices.LogManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace UIG.Accounting.DataServices
{
    /// <summary>
    ///Application Detail DAO class provides all Application Detail module related Data operation
    /// </summary>
    /// <history>
    ///  Author				:	Saravanan R
    ///  Creation Date		:	23/5/2016
    ///  </history>
    public class UserDAO
    { ///// <summary>
        ///AuthenticateUser method accepts Login object  as input  to validate the user
        /// </summary>
        /// <returns>
        /// 0 if Success, 1 if error
        /// </returns>
        /// <history>
        ///  Author				:	Saravanan R
        ///  Creation Date		:	23/5/2016
        ///  </history>
        public int AuthenticateUser(UserModel user)
        {
           // ProductLogManager.TraceWrite("Authenticate User Data Component");
            int i = 0;
            try
            {
                //i = 1;
              i = Convert.ToInt32(ProductDB.DBInstance.ExecuteScalar(StoredProcConstants.AUTHENTICATEUSER, user.UserName, user.Password)); //TODO: Implement Stored Procedure and Uncomment me
            }
            catch (SqlException ex)
            {
                ProductLogManager.DebugWrite(ex.Message + " " + ex.ErrorCode + "  " + ex.Number);
                //i = 1;
            }
            catch (Exception e)
            {
                ProductLogManager.DebugWrite(e.Message);
                //i = 1;
            }
            return i;
        }
        }
        }