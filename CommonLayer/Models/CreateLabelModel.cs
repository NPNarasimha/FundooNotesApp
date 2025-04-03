using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models
{
    public class CreateLabelModel
    {
        [Required(ErrorMessage ="Mandatory")]
        public string LabelName { get; set; }
    }
}
