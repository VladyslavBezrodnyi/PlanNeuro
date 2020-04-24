using Microsoft.EntityFrameworkCore;
using PlanNeuro.BLL.Interfaces;
using PlanNeuro.DAL.Context;
using PlanNeuro.DAL.Entities;
using PlanNeuro.DAL.Interfaces;
using PlanNeuro.Domain.DataObjects;
using PlanNeuro.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.BLL.Services
{
    public class ConversationService : IConversationService
    {
        private readonly IUnitOfWork db;

        public ConversationService(IUnitOfWork db)
        {
            this.db = db;
        }

        public async Task<MessageDTO> AddMessage(MessageDTO message)
        {
            return await db.Conversations.AddMessage(message);
        }

        public async Task<List<MessageDTO>> GetMessages(int boardId, UserData user)
        {
            return await db.Conversations.GetMessages(boardId, user);
        }
    }
}