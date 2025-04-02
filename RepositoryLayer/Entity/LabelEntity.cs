using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
using RepositoryLayer.Migrations;

namespace RepositoryLayer.Entity
{
    public class LabelEntity
    {
        [Key]//for primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //identity(1,1) genareted
        public int LabelId { get; set; }
        public string LabelName { get; set; }=string.Empty;
        
        public int UserId { get; set; }
        [JsonIgnore]
        public UserEntity User { get; set; }= null!;
        // Many-to-Many Relationship with Notes
        public ICollection<NoteLabel> NoteLabels { get; set; } = new List<NoteLabel>();

    }
}
