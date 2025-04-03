using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mandatory")]
        [EmailAddress(ErrorMessage = "Incorrect Formate of E-Mail")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Mandatory")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password should be 5 characters")]

        public string Password { get; set; }
    }
}
