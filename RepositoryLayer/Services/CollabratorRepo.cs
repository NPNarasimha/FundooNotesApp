using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Services
{
    public class CollabratorRepo: ICollabratorRepo
    {
        private readonly FundooDBContext context;

        public CollabratorRepo(FundooDBContext context)
        {
            this.context = context;
        }

        public CollabratorEntity AddCollabrator(int noteId, int userId, string email)
        {
            try
            {
                var collabratorRes = context.Notes.FirstOrDefault(x => x.NotesId == noteId);
                var colabUserRes = context.Users.FirstOrDefault(x => x.Email == email);
                if (collabratorRes != null || colabUserRes != null)
                {
                    CollabratorEntity collabrator = new CollabratorEntity();
                    collabrator.UserId = userId;
                    collabrator.Email = email;
                    collabrator.NoteId = noteId;
                    context.Collabrator.Add(collabrator);
                    context.SaveChanges();
                    return collabrator;

                }
                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CollabratorEntity> GetCollabrator(int userId)
        {
            var collabrateRes=context.Collabrator.ToList().FindAll(x => x.UserId == userId);
            if (collabrateRes != null)
            {
                return collabrateRes;
            }
            return null;
        }

        public bool RemoveCollabrator(int collabrateoId)
        {
            try
            {
                var colabRes = context.Collabrator.FirstOrDefault(x => x.CollabrationId == collabrateoId);
                if (colabRes != null)
                {
                    context.Collabrator.Remove(colabRes);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
