using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonyTansfer.Exeptions
{
    [System.Serializable]
    public class TransferExpetion : Exception
    {
        public TransferExpetion() { }
        public string TransferField
        {
            get
            {
                return Message;
            }
        }
        public TransferExpetion(string message) : base(message) { }
        public TransferExpetion(string message, Exception inner) : base(message, inner) { }
        protected TransferExpetion(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
