using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.MobileApp.Models
{
    public class Phone
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public int UserType { get; set; }
        public string Number { get; set; }
        public string Token { get; set; }
        public int State { get; set; }
    }
}
