using DataAccess;
using DataAccess.Models;
using DataAccess.Repositories;

namespace DataAccess.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        public IQuestRepository QuestRepo { get; }

        // public GenericRepository<Availability> AvailabilityRepo { get; }
        public void Save();

    }
}
