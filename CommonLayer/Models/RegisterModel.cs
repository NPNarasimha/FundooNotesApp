using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Mandatory")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "First Name should be 5 characters")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "Mandatory")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Last Name should be 5 characters")]

        public string LastName { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Mandatory")]

        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Mandatory")]
        [EmailAddress(ErrorMessage = "Incorrect Formate of E-Mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mandatory")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password should be 5 characters")]
        public string Password { get; set; }
    }
}
