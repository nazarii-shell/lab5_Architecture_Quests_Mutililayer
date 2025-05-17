using DataAccess.Models;
using DTOS;


namespace DataAccess.Repositories
{
    public interface IQuestRepository
    {
        List<Quest> Find(string query);
        List<Quest> GetAll();
        Quest Book(int questId, TimeOnly time, int peopleCount, bool haveGiftCard);

        Quest Create(Quest quest);
        
        int Delete(int questId);
    }
}