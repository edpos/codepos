using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace UIG.Accounting.CrosscuttingServices.ExceptionManagement
{
    /// <summary>
    ///For Enterprise Library 6,Exception Manager has to be set before we perform operation .  Initial class that initialize it
    /// </summary>
    /// <history>
    ///  Author				:	Edwin J
    ///  Creation Date		:	18/2/2014
    ///  </history>
    public class ExceptionBootStrapper
    {
        public static void Start()
        {
            IConfigurationSource config = ConfigurationSourceFactory.Create();
            ExceptionPolicyFactory factory = new ExceptionPolicyFactory(config);
            //ExceptionPolicy.SetExceptionManager(factory.CreateManager());
        }
    }
}