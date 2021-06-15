using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String User { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public Boolean Mode { get; set; }
    }
}
