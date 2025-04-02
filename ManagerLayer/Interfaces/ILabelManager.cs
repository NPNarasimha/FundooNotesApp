using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Entity;

namespace ManagerLayer.Interfaces
{
    public interface ILabelManager
    {
        public Task<LabelEntity> createLabel(int userId, string name);
        public Task<LabelEntity> updateLabel(int userId,int labelId, string name);
        public Task<List<LabelEntity>> GetAllLabels(int userId);

        public Task<bool> deleteLabelToNote(int noteId, int labelId);
        public Task<bool> AssiginLabelToNote(int noteId, int labelId);
    }
}
