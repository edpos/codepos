using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace iTanec.eCom.Services.LogManagment
{
    /// <summary>
    ///For Enterprise Library 6, Log writer has to be set before we perform operation on Log Entry.  Initial class that initialize it
    /// </summary>
    /// <history>
    ///  Author				:	Edwin J
    ///  Creation Date		:	11/2/2014
    ///  </history>
    public class LoggerBootstrapper
    {
        public static void Start()
        {
            Logger.SetLogWriter(new LogWriterFactory().Create());
        }
    }
}