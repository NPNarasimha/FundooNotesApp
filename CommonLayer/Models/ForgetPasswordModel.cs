using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models
{
    public class ForgetPasswordModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Mandatory")]
        [EmailAddress(ErrorMessage = "Incorrect Formate of E-Mail")]

        public string Email { get; set; }
        public string Token { get; set; }
    }
}
