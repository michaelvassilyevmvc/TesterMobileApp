using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tester.WebApi.Service.Models
{
    public class Phone
    {
        [Required]
        public long ID { get; set; }
        [Required]
        public long UserID { get; set; }
        public User User { get; set; }
        [Required]
        public int UserType { get; set; }
        [Required]
        public string Number { get; set; }
        public string Token { get; set; }
        [Required]
        public int State { get; set; }


    }
}
