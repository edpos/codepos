using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;

namespace iTanec.eCom.Services.ExceptionManagement
{
    /// <summary>
    /// Exception Manager is base exception class that defines how the exceptions to be handled.
    /// </summary>
    /// <history>
    ///  Author				:	Edwin J
    ///  Creation Date		:	16/12/2013
    ///  Last revised		:
    ///  Revision history	:
    /// </history>
    public class ProductExceptionManager
    {
        /// <summary>
        /// To handle the exception as per policy defined in Configuration file
        /// </summary>
        /// <param name="exceptionToHandle"></param>
        /// <returns></returns>
        public static bool HandleException(Exception exceptionToHandle)
        {
            return ExceptionPolicy.HandleException(exceptionToHandle,
                "Policy");
        }
    }
}