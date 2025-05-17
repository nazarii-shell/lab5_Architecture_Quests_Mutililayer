using BusinessLogic.Models;
using DataAccess.Models;
using DataAccess.UoW;
using AutoMapper;
using DTOS;


namespace BusinessLogic;

public class QuestService : IQuestService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public QuestService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public List<QuestBussinessModel> Find(string query)
    {
        var found = _unitOfWork.QuestRepo.Find(query);
        var questBussinessModels = _mapper.Map<List<QuestBussinessModel>>(found);
        return questBussinessModels;
    }

    public List<QuestBussinessModel> GetALL()
    {
        var found = _unitOfWork.QuestRepo.GetAll();
        var questBussinessModels = _mapper.Map<List<QuestBussinessModel>>(found);
        return questBussinessModels;
    }

    public QuestBussinessModel Book(int questId, TimeOnly time, int people_count, bool haveGiveCard)
    {
        var quest = _unitOfWork.QuestRepo.Book(questId, time, people_count, haveGiveCard);
        return _mapper.Map<QuestBussinessModel>(quest);
    }

    public QuestBussinessModel Create(QuestDto questDto)
    {
        var questBissinesModel = _mapper.Map<Quest>(questDto);

        // var newQuest = new Quest
        // {
        //     Name = questDto.Name,
        //     Price = questDto.Price,
        //     ParticipantsLimit = questDto.ParticipantsLimit,
        //     Availabilities = new List<Availability>()
        //     {
        //         new() {StartTime = questDto.Availabilities[0].StartTime, EndTime = questDto.Availabilities[0].EndTime}
        //     }
        // };
        
        var quest = _unitOfWork.QuestRepo.Create(questBissinesModel);
        _unitOfWork.Save();
        return _mapper.Map<QuestBussinessModel>(quest);
    }
    

    public int Delete(int questId)
    {
        return _unitOfWork.QuestRepo.Delete(questId);
    }
}