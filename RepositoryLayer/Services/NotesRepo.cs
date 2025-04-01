using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Services
{
    public class NotesRepo : INotesRepo
    {
        private readonly FundooDBContext context;
        private readonly IConfiguration configuration;

        public NotesRepo(FundooDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
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


        public bool NotePin(int noteId, int userId)
        {
            var pinNote = context.Notes.FirstOrDefault(x => x.NotesId == noteId && x.UserId == userId);
            if (pinNote != null)
            {
                if (pinNote.IsPin)
                {
                    pinNote.IsPin = false;
                    
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    pinNote.IsPin = true;
                    context.SaveChanges();
                    return false;
                }
            }
            return false;
        }
        
        public bool NoteArchive(int userId,int noteId)
        {
            var archiveNote = context.Notes.FirstOrDefault(x => x.UserId == userId && x.NotesId == noteId);
            if (archiveNote != null)
            {
                if (archiveNote.IsArchive && archiveNote.IsPin == false)
                {
                    archiveNote.IsArchive = false;
                    archiveNote.IsPin = true;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    archiveNote.IsArchive = true;
                    archiveNote.IsPin = false;
                    context.SaveChanges();
                    return false;
                }
            }
            return false;
        }

        public bool TrashNote(int noteId, int userid)
        {
            var note = context.Notes.FirstOrDefault(x => x.UserId == userid && x.NotesId == noteId);
            if (note != null)
            {
                if (note.IsTrash)
                {
                    note.IsTrash = false;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    note.IsTrash = true;
                    context.SaveChanges();
                    return false;
                }
            }
            return false;
        }
        public bool AddColor(int noteId, int userId, string color)
        {
            var note = context.Notes.FirstOrDefault(x => x.UserId == userId && x.NotesId == noteId);
            if (note != null)
            {
                note.Color = color;
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool reminderNote(int noteId,DateTime reminder)
        {
            var note = context.Notes.FirstOrDefault(x => x.NotesId == noteId);
            if (note != null)
            {
                note.Reminder = reminder;
                context.SaveChanges();
                return true;
            }
            else
            {
                    
                 return false;
                
            }
         
        }
        //install the pakage CloudinaryDotNet[version is latest].
        public bool  AddImage(int noteId, int userId, IFormFile image)
        {
            var note = context.Notes.FirstOrDefault(x => x.UserId == userId && x.NotesId == noteId);
            if (note != null)
            {
                Account account = new Account(
                    configuration["CloudinarySettings:CloudName"],
                    configuration["CloudinarySettings:ApiKey"],
                    configuration["CloudinarySettings:ApiSecret"]
                    );
                Cloudinary cloudinary = new Cloudinary(account);
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(image.FileName,image.OpenReadStream()),

                };
                var uploadResult = cloudinary.Upload(uploadParams);
                string imagePath = uploadResult.Url.ToString();
                note.Image = imagePath;
                context.SaveChanges();
                return true;
            }  
            return false;
        }

    }
}
