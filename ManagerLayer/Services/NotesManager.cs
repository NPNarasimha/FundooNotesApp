using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.Models;
using ManagerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;

namespace ManagerLayer.Services
{
    public class NotesManager: INotesManager
    {
        private readonly INotesRepo notesRepo;

        public NotesManager(INotesRepo notesRepo)
        {
            this.notesRepo = notesRepo;
        }
        public NotesEntity AddingNotes(int UserId, NotesModel notesModel)
        {
            return notesRepo.AddingNotes(UserId, notesModel);
        }
        public NotesEntity UpdateNotes(int UserId, int NotesId, NotesModel UpdateModel)
        {
            return notesRepo.UpdateNotes(UserId, NotesId, UpdateModel);
        }
       

        public List<NotesEntity> GetAllNotes(int userId)
        {
            return notesRepo.GetAllNotes(userId);
        }
        public bool DeleteNotes(int UserId, int NotesId)
        {
            return notesRepo.DeleteNotes(UserId, NotesId);
        }

        public List<NotesEntity> FetchNotes(string title, string description)
        {
            return notesRepo.FetchNotes(title, description);
        }
        public int CountUserNotes(int userId)
        {
            return notesRepo.CountUserNotes(userId);
        }
    }
}
