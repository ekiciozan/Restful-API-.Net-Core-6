using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RestfulWebApiEx.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
     
       [MaxLength(250)]
        public string Username { get; set; }
      
        [MaxLength(250)]
        public string Password { get; set; }
       
     
    }
}