using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tester.WebApi.Service.Models
{
    public class RecoveryEvent
    {
        [Required]
        public long ID { get; set; }
        [Required]
        public string IIN { get; set; }
        [Required]
        public  int RegionID { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string AcceptValue { get; set; }
        [Required]
        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}
