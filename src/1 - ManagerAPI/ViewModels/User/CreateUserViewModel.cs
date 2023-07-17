using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}