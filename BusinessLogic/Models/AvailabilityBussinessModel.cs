
namespace BusinessLogic.Models
{
    public class AvailabilityBussinessModel
    {
            public int Id { get; set; }

            public TimeOnly StartTime { get; set; }

            public TimeOnly EndTime { get; set; }

            // Navigation Property
            public QuestBussinessModel Quest { get; set; }
    }
}
