using iTanec.eCom.Common.General;
using Microsoft.Practices.EnterpriseLibrary.Data;

using UIG.Accounting.Common;

namespace UIG.Accounting.CrosscuttingServices.DataManagement
{
    /// <summary>
    /// Database class provides property for instance of DB
    /// </summary>
    /// <history>
    ///  Author				:	Saravanan R
    ///  Creation Date		:	16/1/2014
    ///  Last revised		:
    ///  Revision history	:
    /// </history>
    public static class ProductDB
    {
        public static Database DBInstance
        {
            get
            {
                Database dbInst = GenericSingleton<DBFactory>.Instance.Database;
                return dbInst;
            }
        }
    }
}