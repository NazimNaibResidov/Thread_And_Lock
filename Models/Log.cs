using System;

namespace MonyTansfer.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string FromAcound { get; set; }
        public string ToAcound { get; set; }
        public decimal TransferAmount { get; set; }
        public DateTime TransferDate { get; set; }
        public bool isSuccessFul { get; set; }
        public string FailedReason { get; set; }
    }
}
