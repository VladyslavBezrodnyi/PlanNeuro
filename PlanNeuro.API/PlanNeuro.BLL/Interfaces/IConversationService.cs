using PlanNeuro.Domain.DataObjects;
using PlanNeuro.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.BLL.Interfaces
{
    public interface IConversationService
    {
        Task<MessageDTO> AddMessage(MessageDTO message);
        Task<List<MessageDTO>> GetMessages(int boardId, UserData user);
    }
}
