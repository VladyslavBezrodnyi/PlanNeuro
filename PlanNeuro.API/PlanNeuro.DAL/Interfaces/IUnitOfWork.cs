using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBoardRepository Boards { get; }
        ICardRepository Cards { get; }
        ICardsListRepository CardsLists { get; }
        IConversationRepository Conversations { get; }
        IRatingRepository Raitings { get; }
        Task SaveAsync();
    }
}
