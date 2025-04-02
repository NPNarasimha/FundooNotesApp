using System;
using System.Collections.Generic;
using System.Text;
using RepositoryLayer.Entity;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ILabelRepo
    {
        public Task<LabelEntity> createLabel(int userId, string name);
        public Task<LabelEntity> updateLabel(int userId,int labelId, string name);
        public Task<bool> deleteLabelToNote(int noteId, int labelId);
        public Task<List<LabelEntity>> GetAllLabels(int userId);

        public Task<bool> AssiginLabelToNote(int noteId, int labelId);

    }
}
