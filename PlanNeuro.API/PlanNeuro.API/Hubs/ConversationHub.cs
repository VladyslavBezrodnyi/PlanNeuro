using Microsoft.AspNetCore.SignalR;
using PlanNeuro.BLL.Interfaces;
using PlanNeuro.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanNeuro.API.Hubs
{
    public class ConversationHub : Hub
    {
        public IConversationService _conversationService;

        public ConversationHub(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }

        public async Task Send(MessageDTO message)
        {
            message = await _conversationService.AddMessage(message);
            await Clients.Group(message.BoardId.ToString()).SendAsync("Receive", message);
        }

        public async Task Enter(string conversationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId);
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}
