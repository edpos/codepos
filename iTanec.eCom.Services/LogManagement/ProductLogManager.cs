using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace iTanec.eCom.Services.LogManagement
{
    /// <summary>
    /// Log Manager is base class that defines how logging is configured.
    /// </summary>
    /// <history>
    ///  Author				:	Edwin J
    ///  Creation Date		:	16/12/2013
    ///  Last revised		:
    ///  Revision history	:
    /// </history>
    public class ProductLogManager
    {
        /// <summary>
        /// This method defines how default exception would be logged.
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static void Write(string message)
        {
            LogEntry entry = new LogEntry()
            {
                Message = message,
                Severity = System.Diagnostics.TraceEventType.Critical
            };
            Logger.Write(entry);
        }

        /// <summary>
        /// Helper method to write debug information in debug file.
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static void DebugWrite(string message)
        {
            if (Logger.IsLoggingEnabled())
            {
                LogEntry log = new LogEntry();
                log.Message = message;
                log.Categories.Add("DebugLog");
                log.Severity = System.Diagnostics.TraceEventType.Information;
                Logger.Write(log);
            }
        }

        /// <summary>
        /// Helper method to write Trace information in Trace file.
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static void TraceWrite(string message)
        {
            if (Logger.IsLoggingEnabled())
            {
                LogEntry log = new LogEntry();
                log.Message = message;
                log.Categories.Add("TraceLog");
                log.Severity = System.Diagnostics.TraceEventType.Verbose;
                Logger.Write(log);
            }
        }
    }
}