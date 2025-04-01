using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.Models;
using ManagerLayer.Interfaces;
using Microsoft.AspNetCore.Http;
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
        public bool NotePin(int noteId, int userId)
        {
            return notesRepo.NotePin(noteId, userId);
        }
        public bool NoteArchive(int userId, int noteId)
        {
            return notesRepo.NoteArchive(userId, noteId);
        }
        public bool TrashNote(int noteId, int userid)
        {
            return notesRepo.TrashNote(noteId, userid);
        }
        public bool AddColor(int noteId, int userId, string color)
        {
            return notesRepo.AddColor(noteId, userId, color);
        }
        public bool reminderNote(int noteId, DateTime reminder)
        {
            return notesRepo.reminderNote(noteId, reminder);
        }
        public bool AddImage(int noteId, int userId, IFormFile image)
        {
            return notesRepo.AddImage(noteId, userId, image);
        }
    }
}
