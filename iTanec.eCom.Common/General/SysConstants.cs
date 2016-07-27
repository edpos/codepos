using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTanec.eCom.Common.General
{
    public class SysConstants
    {
        public const string IMAGE_PATH = "\\img\\";

        public enum Role
        {
            SuperAdmin = 1
        }

        public enum Gender
        {
            MALE = 1,
            FEMALE = 2,
            Other = 3
        }

        public enum AccessRights
        {
            READ = 1,
            READ_WRITE = 2,
            DELETE = 3
        }
    }

}
