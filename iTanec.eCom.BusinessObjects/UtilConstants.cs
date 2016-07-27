using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTanec.eCom.BusinessObjects
{
    public class UtilConstants
    {
        static UtilConstants()
        {
            InvalidDate = new DateTime(1900, 1, 1);
        }
        public const int InvalidSeqId = -1;
        public const Int64 InvalidSeqIdInt64 = -1;
        public const Int16 InvalidSeqIdInt16 = -1;
        public static readonly DateTime InvalidDate;
        public const int InvalidInt = int.MinValue;
        public const decimal InvalidDecimal = decimal.MinValue;
        public const float InvalidFloat = float.MinValue;
        public const double InvalidDouble = double.MinValue;


       
    }
}
