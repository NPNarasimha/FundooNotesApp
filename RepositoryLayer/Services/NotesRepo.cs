using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLayer.Models;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Services
{
    public class NotesRepo : INotesRepo
    {
        private readonly FundooDBContext context;

        public NotesRepo(FundooDBContext context)
        {
            this.context = context;
        }
        public NotesEntity AddingNotes(int UserId, NotesModel notesModel)
        {
            NotesEntity notes = new NotesEntity();
            notes.Title = notesModel.Title;
            notes.Description = notesModel.Description;
            notes.CreatedAt = DateTime.Now;
            notes.ModifiedAt = DateTime.Now;
            notes.UserId = UserId;
            context.Notes.Add(notes);
            context.SaveChanges();
            return notes;
        }


        public List<NotesEntity> GetAllNotes(int userId)
        {
            var notes = context.Notes.ToList().FindAll(x => x.UserId == userId);
            if (notes != null)
            {
                return notes;
            }
            else
            {
                return null;
            }

        }

        public NotesEntity UpdateNotes(int UserId, int NotesId, NotesModel model)
        {
            var notes = context.Notes.FirstOrDefault(x => x.UserId == UserId && x.NotesId == NotesId);
            if (notes != null)
            {
                notes.Title = model.Title;
                notes.Description = model.Description;
                notes.IsArchive = model.IsArchive;
                notes.IsPin = model.IsPin;
                notes.IsTrash = model.IsTrash;
                notes.Color = model.Color;
                notes.CreatedAt = DateTime.Now;
                notes.ModifiedAt = DateTime.Now;
                context.Notes.Update(notes);
                context.SaveChanges();
                return notes;
            }
            else
            {
                return null;
            }
        }

        public bool DeleteNotes(int UserId, int NotesId)
        {
            var notes = context.Notes.FirstOrDefault(x => x.UserId == UserId && x.NotesId == NotesId);
            if (notes != null)
            {
                context.Notes.Remove(notes);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //Fetch Notes using title and description
        public List<NotesEntity> FetchNotes(string title, string description)
        {
            var notes = context.Notes.ToList().FindAll(x => x.Title == title && x.Description == description);
            if (notes.Any())
            {
                return notes;
            }
            else
            {
                return null;
            }
        }
        //Return Count of notes a user has

        public int CountUserNotes(int userId)
        {
            var countNotes = context.Notes.Count(x => x.UserId == userId);
            if (countNotes != null)
            {
                return countNotes;
            }
            return 0;
        }





    }
}
