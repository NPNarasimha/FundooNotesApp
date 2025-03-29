using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.Models;
using RepositoryLayer.Entity;

namespace ManagerLayer.Interfaces
{
    public interface INotesManager
    {
        public NotesEntity AddingNotes(int UserId, NotesModel notesModel);
        public NotesEntity UpdateNotes(int UserId, int NotesId, NotesModel UpdateModel);
       
        public List<NotesEntity> GetAllNotes(int userId);
        public bool DeleteNotes(int UserId, int NotesId);

        public List<NotesEntity> FetchNotes(string title, string description);
        public int CountUserNotes(int userId);
    }
}
