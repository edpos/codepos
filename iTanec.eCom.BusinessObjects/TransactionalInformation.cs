using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTanec.eCom.BusinessObjects
{
    public class TransactionalInformation
    {
        public TransactionalInformation()
        {
            ReturnMessage = new List<string>();
            ReturnStatus = true;
            ValidationErrors = new Hashtable();
        }
        public bool ReturnStatus { get; set; }
        public List<string> ReturnMessage { get; set; }
        public Hashtable ValidationErrors;
    }
}
