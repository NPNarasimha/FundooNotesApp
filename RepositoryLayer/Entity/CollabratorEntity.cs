using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RepositoryLayer.Entity
{
    public class CollabratorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CollabrationId { get; set; }
        public string Email { get; set; }
        [ForeignKey("NoteUser")]
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual NotesEntity NoteUser { get; set; }

        [ForeignKey("CollabrationNote")]
        public int NoteId { get; set; }
        [JsonIgnore]
        public virtual NotesEntity CollabrationNote { get; set; }
    }
}
