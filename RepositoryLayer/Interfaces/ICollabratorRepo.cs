using System;
using System.Collections.Generic;
using System.Text;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Interfaces
{
    public interface ICollabratorRepo
    {
        public CollabratorEntity AddCollabrator(int noteId, int userId, string email);
        public List<CollabratorEntity> GetCollabrator(int userId);
        public bool RemoveCollabrator(int userId);
    }
}
