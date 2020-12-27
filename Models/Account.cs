using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonyTansfer.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccoundNumber { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
    }
}
