using DataAccess.Models;

namespace BusinessLogic.Models;

public class QuestBussinessModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int ParticipantsLimit { get; set; }

    public List<Availability> Availabilities { get; set; } = new List<Availability>();


    public override string ToString()
    {
        var availableTime = "";

        foreach (var availability in Availabilities)
        {
            availableTime += $"{availability.StartTime} - {availability.EndTime}; ";
        }

        return
            $"Id: {Id}, Name: {Name}, Price: {Price}, ParticipantsLimit: {ParticipantsLimit}, AvailableTime: {availableTime}";
    }
}