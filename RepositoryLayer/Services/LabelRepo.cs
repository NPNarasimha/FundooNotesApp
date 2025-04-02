using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Services
{
    public class LabelRepo: ILabelRepo
    {
        private readonly FundooDBContext context;
        public LabelRepo(FundooDBContext context)
        {
            this.context = context;
        }

        public async Task<LabelEntity> createLabel(int userId,string name)
        {
            var userRes = context.Users.FirstOrDefault(x=>x.UserId==userId);
            if (userRes == null)
            {
                return null;
            }
            else
            {
                LabelEntity label = new LabelEntity { LabelName=name,UserId=userId};
                context.Labels.Add(label);
                await context.SaveChangesAsync();
                return label;
            }
        }
        public async Task<List<LabelEntity>> GetAllLabels(int userId)
        {
           var res=context.Labels.Where(x=>x.UserId == userId).ToList();
            if(res == null)
            {
                return null;
            }
            return res;
        }

        public async Task<LabelEntity> updateLabel(int userId,int labelId, string name)
        {
            var labelRes = context.Labels.FirstOrDefault(x => x.LabelId == labelId);
            if (labelRes == null)
            {
                return null;
            }
            else
            {
                labelRes.LabelName = name;
                await context.SaveChangesAsync();
                return labelRes;
            }
        }
        public bool deleteLabelFromNote(int userId,int noteId, int labelId)
        {
            var note = context.NoteLabels.FirstOrDefault(x =>x.NoteId==noteId && x.LabelId==labelId);
            if (note == null)
            {
                return false;
            }
            else
            {
                context.NoteLabels.Remove(note);
                context.SaveChanges();
                return true;
            }
        }
        public async Task<LabelEntity> AssiginLabelToNote(int labelId, int noteId)
        {
            var labelRes = context.Labels.FirstOrDefault(x => x.LabelId == labelId);
            var noteRes = context.Notes.FirstOrDefault(x => x.NotesId == noteId);
            if (labelRes == null || noteRes == null)
            {
                return null;
            }
            else
            {
                context.NoteLabels.Add(new NoteLabel {NoteId=noteId,LabelId=labelId });
                await context.SaveChangesAsync();
                return labelRes;
            }
        }

    }
}
