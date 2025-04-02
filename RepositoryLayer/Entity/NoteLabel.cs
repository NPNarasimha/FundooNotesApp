using System;
using System.Collections.Generic;
using System.Text;
using RepositoryLayer.Migrations;

namespace RepositoryLayer.Entity
{
    public class NoteLabel
    {
        public int NoteId { get; set; }
        public NotesEntity Note { get; set; }
        public int LabelId { get; set; }
        public LabelEntity Label { get; set; }
    }
}
