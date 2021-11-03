using System;
using System.ComponentModel.DataAnnotations;


namespace Tester.WebApi.Service.Models
{
    public class User
    {
        [Required]
        public long ID { get; set; }
        [Required]
        [MaxLength(12)]
        public string IIN { get; set; }
        [Required]
        public int RegionID { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string AcceptValue { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RequestDate { get; set; } = DateTime.Now;

    }
}
