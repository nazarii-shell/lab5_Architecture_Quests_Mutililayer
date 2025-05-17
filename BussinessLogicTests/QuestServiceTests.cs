using Xunit;
using Moq;
using AutoMapper;
using BusinessLogic;
using BusinessLogic.Models;
using DataAccess.Models;
using DataAccess.UoW;
using DataAccess.Repositories;


public class QuestServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IQuestRepository> _questRepoMock;
    private readonly QuestService _service;

    public QuestServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();
        _questRepoMock = new Mock<IQuestRepository>();

        // Set up the repo property on UnitOfWork
        _unitOfWorkMock.Setup(u => u.QuestRepo).Returns(_questRepoMock.Object);

        _service = new QuestService(_unitOfWorkMock.Object, _mapperMock.Object);
    }

    [Fact]
    public void Find_ReturnsMappedBusinessModels()
    {
        // Arrange
        var query = "Haunted";

        var questEntities = new List<Quest>
        {
            new Quest { Id = 1, Name = "Haunted House", Price = 100, ParticipantsLimit = 5, Availabilities = new List<Availability>() },
            new Quest { Id = 2, Name = "Ghost Castle", Price = 150, ParticipantsLimit = 6, Availabilities = new List<Availability>() }
        };

        var mappedBusinessModels = new List<QuestBussinessModel>
        {
            new QuestBussinessModel { Id = 1, Name = "Haunted House", Price = 100, ParticipantsLimit = 5 },
            new QuestBussinessModel { Id = 2, Name = "Ghost Castle", Price = 150, ParticipantsLimit = 6 }
        };

        _questRepoMock.Setup(r => r.Find(query)).Returns(questEntities);
        _mapperMock.Setup(m => m.Map<List<QuestBussinessModel>>(questEntities)).Returns(mappedBusinessModels);

        // Act
        var result = _service.Find(query);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("Haunted House", result[0].Name);
    }

    [Fact]
    public void Book_ReturnsMappedQuest_WhenValid()
    {
        // Arrange
        int questId = 1;
        TimeOnly time = new TimeOnly(15, 0);
        int peopleCount = 4;
        bool haveGiftCard = false;

        var quest = new Quest
        {
            Id = questId,
            Name = "Adventure Escape",
            Price = 200,
            ParticipantsLimit = 5,
            Availabilities = new List<Availability>
            {
                new Availability { StartTime = new TimeOnly(14, 0), EndTime = new TimeOnly(16, 0) }
            }
        };

        var expectedModel = new QuestBussinessModel
        {
            Id = questId,
            Name = "Adventure Escape",
            Price = 200,
            ParticipantsLimit = 5
        };

        _questRepoMock.Setup(r => r.Book(questId, time, peopleCount, haveGiftCard)).Returns(quest);
        _mapperMock.Setup(m => m.Map<QuestBussinessModel>(quest)).Returns(expectedModel);

        // Act
        var result = _service.Book(questId, time, peopleCount, haveGiftCard);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Adventure Escape", result.Name);
        Assert.Equal(200, result.Price);
    }

    [Fact]
    public void Book_ThrowsException_WhenTimeInvalid()
    {
        // Arrange
        int questId = 1;
        TimeOnly time = new TimeOnly(10, 0); // outside available range
        int peopleCount = 4;
        bool haveGiftCard = false;

        var quest = new Quest
        {
            Id = questId,
            Name = "Early Bird Escape",
            Price = 150,
            ParticipantsLimit = 4,
            Availabilities = new List<Availability>
            {
                new Availability { StartTime = new TimeOnly(12, 0), EndTime = new TimeOnly(14, 0) }
            }
        };

        _questRepoMock.Setup(r => r.Book(questId, time, peopleCount, haveGiftCard))
                      .Throws(new Exception("Time is invalid. Available time is 12:00 - 14:00"));

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => _service.Book(questId, time, peopleCount, haveGiftCard));
        Assert.Contains("Time is invalid", ex.Message);
    }
}
