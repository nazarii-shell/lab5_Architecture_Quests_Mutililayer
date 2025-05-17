using AutoMapper;
using BusinessLogic.Models;
using DataAccess.Models;
using DTOS;

namespace BusinessLogic.Profiles
{
    public class QuestProfile : Profile
    {
        public QuestProfile()
        {
            CreateMap<Quest, QuestBussinessModel>();
            CreateMap<QuestDto, QuestBussinessModel>();
            CreateMap<QuestDto, Quest>();
            CreateMap<QuestBussinessModel, Quest>();
        }
    }
}
