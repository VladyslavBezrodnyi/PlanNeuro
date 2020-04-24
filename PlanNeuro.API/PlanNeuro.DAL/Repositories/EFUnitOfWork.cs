using PlanNeuro.DAL.Context;
using PlanNeuro.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;
        private IBoardRepository boards;
        private ICardRepository cards;
        private ICardsListRepository cardsLists;
        private IConversationRepository conversations;
        private IRatingRepository raitings;


        public IBoardRepository Boards => boards ?? new BoardRepository(db);

        public ICardRepository Cards => cards ?? new CardRepository(db);

        public ICardsListRepository CardsLists => cardsLists ?? new CardsListRepository(db);

        public IConversationRepository Conversations => conversations ?? new ConversationRepository(db);

        public IRatingRepository Raitings => raitings ?? new RatingRepository(db);


        public EFUnitOfWork(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                    db.Dispose();
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~EFUnitOfWork()
        // {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            GC.SuppressFinalize(this);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
