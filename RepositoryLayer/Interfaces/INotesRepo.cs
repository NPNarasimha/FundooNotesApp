using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Interfaces
{
    public interface INotesRepo
    {
        public NotesEntity AddingNotes(int UserId, NotesModel notesModel);
        public NotesEntity UpdateNotes(int UserId, int NotesId, NotesModel UpdateModel);
        
        public List<NotesEntity> GetAllNotes(int userId);
        public bool DeleteNotes(int UserId, int NotesId);

        public List<NotesEntity> FetchNotes(string title, string description);
        public int CountUserNotes(int userId);
        public bool NotePin(int noteId, int userId);
        public bool NoteArchive(int userId, int noteId);
        public bool TrashNote(int noteId, int userid);
        public bool AddColor(int noteId, int userId, string color);
        public bool reminderNote(int noteId, DateTime reminder);
        public bool AddImage(int noteId, int userId, IFormFile image);
    }
}
