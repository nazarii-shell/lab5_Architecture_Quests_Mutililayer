using BusinessLogic.Models;
using DataAccess.Models;
using DTOS;

namespace BusinessLogic
{
    public interface IQuestService
    {
        List<QuestBussinessModel> Find(string query);
        List<QuestBussinessModel> GetALL();
        QuestBussinessModel Book(int questId, TimeOnly time, int people_count, bool haveGiveCard);

        public QuestBussinessModel Create(QuestDto questDto);
        public int Delete(int questId);
    }
}