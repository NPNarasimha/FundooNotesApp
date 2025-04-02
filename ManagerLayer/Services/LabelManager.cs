﻿using System;
using System.Collections.Generic;
using System.Text;
using RepositoryLayer.Entity;
using System.Threading.Tasks;
using RepositoryLayer.Interfaces;

using RepositoryLayer.Services;
using ManagerLayer.Interfaces;

namespace ManagerLayer.Services
{
    public class LabelManager : ILabelManager
    {
        private readonly ILabelRepo labelRepo;

        public LabelManager(ILabelRepo labelRepo)
        {
            this.labelRepo = labelRepo;
        }

        public async Task<LabelEntity> createLabel(int userId, string name)
        {
            return await labelRepo.createLabel(userId, name);
        }
        public async Task<LabelEntity> updateLabel(int userId,int labelId, string name)
        {
            return await labelRepo.updateLabel(userId ,labelId, name);
        }
        public bool deleteLabelFromNote(int userId, int noteId, int labelId)
        {
            return labelRepo.deleteLabelFromNote(userId, noteId, labelId);
        }
        public async Task<List<LabelEntity>> GetAllLabels(int userId)
        {
            return await labelRepo.GetAllLabels(userId);
        }
        public async Task<LabelEntity> AssiginLabelToNote(int labelId, int noteId)
        {
            return await labelRepo.AssiginLabelToNote(labelId, noteId);
        }
    }
}
