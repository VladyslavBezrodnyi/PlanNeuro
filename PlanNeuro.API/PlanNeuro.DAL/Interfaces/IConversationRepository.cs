using PlanNeuro.Domain.DataObjects;
using PlanNeuro.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.DAL.Interfaces
{
    public interface IConversationRepository
    {
        Task<MessageDTO> AddMessage(MessageDTO message);
        Task<List<MessageDTO>> GetMessages(int boardId, UserData user);
    }
}
