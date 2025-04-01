using System;
using System.Collections.Generic;
using System.Text;
using ManagerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;

namespace ManagerLayer.Services
{
    public class CollabratorManager : ICollabratorManager
    {
        private readonly ICollabratorRepo collabratorRepo;

        public CollabratorManager(ICollabratorRepo collabratorRepo)
        {
            this.collabratorRepo = collabratorRepo;
        }
        public CollabratorEntity AddCollabrator(int noteId, int userId, string email)
        {
            return collabratorRepo.AddCollabrator(noteId, userId, email);
        }
        public List<CollabratorEntity> GetCollabrator(int userId)
        {
            return collabratorRepo.GetCollabrator(userId);
        }
        public bool RemoveCollabrator(int collabrateoId)
        {
            return collabratorRepo.RemoveCollabrator(collabrateoId);
        }
    }
}
