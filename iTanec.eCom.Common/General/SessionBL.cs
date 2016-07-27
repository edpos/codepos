using System;
using System.Configuration;

namespace iTanec.eCom.Common.General
{
    public class SessionBL
    {
        public SessionVM GetSessionTimeOut()
        {
            int sessionTimeOut = 20;
            int sessionTimerPollInt = 1;
            // setting Code Defaults just in case the conjfig is not ready
            var sessionMngrVM = new SessionVM { ServerSessionTimeOut = sessionTimeOut, ServerPollInterval = sessionTimerPollInt };

            try
            {
                sessionTimeOut = Utilities.GetAppSettingInt("SessionTimeOut");
                sessionTimerPollInt = Utilities.GetAppSettingInt("SessionTimerPollInt");
                sessionMngrVM.ServerSessionTimeOut = sessionTimeOut;
                sessionMngrVM.ServerPollInterval = sessionTimerPollInt;
            }
            catch (Exception exc)
            {
                //Logger.GetInstance().InsertLog(EX, -1, "", -1);
            }
            return sessionMngrVM;
        }
    }
}
