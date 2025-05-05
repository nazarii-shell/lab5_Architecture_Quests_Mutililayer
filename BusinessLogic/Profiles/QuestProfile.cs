using AutoMapper;
using BusinessLogic.Models;
using DataAccess.Models;

namespace BusinessLogic.Profiles
{
    public class QuestProfile : Profile
    {
        public QuestProfile()
        {
            CreateMap<Quest, QuestBussinessModel>();
        }
    }
}
