using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTanec.eCom.Common.General
{
    [Serializable]
    public class ApplicationObject
    {
        public int AppSettingsId { get; set; }
        public int AppSettingsKey { get; set; }
        public string AppSettingsValue { get; set; }
    }
}
