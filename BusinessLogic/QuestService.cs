using BusinessLogic.Models;
using DataAccess.Models;
using DataAccess.UoW;
using AutoMapper;


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

    public QuestBussinessModel Book(int questId, TimeOnly time, int people_count, bool haveGiveCard)
    {
        var quest = _unitOfWork.QuestRepo.Book( questId,  time,  people_count,  haveGiveCard);
        return _mapper.Map<QuestBussinessModel>(quest);
    }
}