using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTanec.eCom.Common.General
{
    [Serializable]
    public class SessionObject
    {
        public int sysUserID { get; set; }
        public int UserSeqId { get; set; }
        public string sysUserName { get; set; }
        public int sysScreenID { get; set; }
        public int sysRootScreenID { get; set; }
        public string sysFirstName { get; set; }
        public string sysLastName { get; set; }
        public string sysSearchString { get; set; }
        public int sysUserRoleID { get; set; }
        public string sysMenuRoleIDs { get; set; }
        public int sysMenuList { get; set; }
        public List<ApplicationObject> applicationObject { get; set; }
    }
}
