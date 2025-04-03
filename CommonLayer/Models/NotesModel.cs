using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace CommonLayer.Models
{
    public class NotesModel
    {
        [Required(ErrorMessage = "Mandatory")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Mandatory")]
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Reminder { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public bool IsArchive { get; set; }
        public bool IsPin { get; set; }
        public bool IsTrash { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ModifiedAt { get; set; }
        
      
    }
}
