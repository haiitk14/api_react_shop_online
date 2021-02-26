using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantAPI.Models.BE
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
