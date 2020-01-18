using Microsoft.EntityFrameworkCore;
using PlanNeuro.BLL.Interfaces;
using PlanNeuro.DAL.Context;
using PlanNeuro.DAL.Entities;
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
        private readonly ApplicationDbContext db;

        public ConversationService(ApplicationDbContext db)
        {
            this.db = db;
        }
        
        public async Task<MessageDTO> AddMessage(MessageDTO message)
        {
            var board = db.Boards
                .Include(b => b.UserBoards)
                .FirstOrDefault(b => b.Id == message.BoardId);
            if (board == null)
            {
                throw new Exception("Board is not exist!");
            }
            if (board.UserBoards.Where(ub => ub.UserId == message.UserId).Count() != 0)
            {
                throw new Exception("User do not have premission!");
            }
            var conversationReplies = new ConversationReply
            {
                BoardId = Convert.ToInt32(message.BoardId),
                UserId = message.UserId,
                Text = message.Text,
                Date = message.Date.ToUniversalTime()
            };
            message.Date = message.Date.ToUniversalTime();
            db.ConversationReplies.Add(conversationReplies);
            await db.SaveChangesAsync();
            return message;
        }

        public async Task<List<MessageDTO>> GetMessages(int boardId,  UserData user)
        {
            var board = db.Boards
                .Include(b => b.UserBoards)
                .FirstOrDefault(b => b.Id == boardId);
            if (board == null)
            {
                throw new Exception("Board is not exist!");
            }
            if (board.UserBoards.Where(ub => ub.UserId == user.Id).Count() != 0)
            {
                throw new Exception("User do not have premission!");
            }
            var messages = await db.ConversationReplies
                .Where(cr => cr.BoardId == boardId)
                .OrderBy(u => u.Date)
                .Select(m =>
                new MessageDTO
                {
                    BoardId = m.BoardId,
                    UserId = m.UserId,
                    Text = m.Text,
                    Date = m.Date
                })
                .ToListAsync();
            return messages;
        }
        
    }
}
