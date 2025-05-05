using BusinessLogic.Models;
using DataAccess.Models;

namespace BusinessLogic
{
    public interface IQuestService
    {
        List<QuestBussinessModel> Find(string query);
        QuestBussinessModel Book(int questId, TimeOnly time, int people_count, bool haveGiveCard);
    }
}