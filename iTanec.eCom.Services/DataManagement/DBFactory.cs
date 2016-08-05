using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;

namespace iTanec.eCom.Services.DataManagement
{
    /// <summary>
    /// DB Factory class provides appropriate instance of DB according to configuration
    /// </summary>
    /// <history>
    ///  Author				:	Saravanan R
    ///  Creation Date		:	16/1/2014
    ///  Last revised		:
    ///  Revision history	:
    /// </history>
    public class DBFactory
    {
        private Database database;

        private string DBType = ConfigurationManager.AppSettings["Datasource"].ToString();

        //Connection string
        public const string ORACLECONNECTION = "OracleDatabase";

        public const string SQLCONNECTION = "SQLDatabase";

        //Constructor class that creates DB instance
        public DBFactory()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            //Check the Prefered DB and invoke specific connection
            switch (DBType)
            {
                case "SQL":
                    database = factory.Create(SQLCONNECTION);
                    break;

                case "ORACLE":
                    database = factory.Create(ORACLECONNECTION);
                    break;

                default:
                    database = factory.Create(SQLCONNECTION);
                    break;
            }
        }

        //Readonly property that returns the connection instance
        public Database Database
        {
            get
            {
                return database;
            }
        }
    }
}