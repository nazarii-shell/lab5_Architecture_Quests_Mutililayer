using DataAccess.Repositories;
using DataAccess.Models;
using lab6;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        //protected readonly LibraryContext _libraryContext;
        protected readonly DbSet<TModel> _dbSet;

        public GenericRepository(QuestsContext context)
        {
            context.Database.EnsureCreated();
            _dbSet = context.Set<TModel>();
        }

        public TModel GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public List<TModel> GetAll()
        {
            var set = _dbSet as DbSet<Quest>;
            return set.Include(item => item.Availabilities).ToList() as List<TModel>;
        }

        public void Create(TModel model)
        {
      
        // _dbSet.SaveChanges();

        // Output confirmation
        // foreach (var q in context.Quests.Include(q => q.Availabilities))
        // {
        //     var a = q.Availabilities.First();
        //     Console.WriteLine($"Quest: {q.Name} | ${q.Price} | Limit: {q.ParticipantsLimit} | Time: {a.StartTime}–{a.EndTime}");
        // }
        }

        public void Update(TModel model)
        {
            _dbSet.Update(model);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public void AddMany(List<TModel> quests)
        {
            _dbSet.AddRange(quests);
        }
    }
}