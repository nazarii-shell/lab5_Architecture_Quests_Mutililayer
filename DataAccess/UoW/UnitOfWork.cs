using DataAccess;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess;

namespace DataAccess.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue;

        private readonly QuestsContext questContext;
        private QuestRepository _questRepo;
        // private GenericRepository<Availability> _availabilityRepo;

        public IQuestRepository QuestRepo => _questRepo ??= new QuestRepository(questContext);

        // public GenericRepository<Availability> AvailabilityRepo => _availabilityRepo ??= new GenericRepository<Availability>(questContext);

        public UnitOfWork(QuestsContext context)
        {
            this.questContext = context;
        }

        public void Save()
        {
            questContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    questContext.Dispose();   
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
