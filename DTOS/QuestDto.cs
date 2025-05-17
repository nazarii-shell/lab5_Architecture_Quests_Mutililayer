namespace DTOS;

public class QuestDto
{
    // public int Id { get; set; }  // Optional if you want to return/edit by Id

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int ParticipantsLimit { get; set; }

    public List<AvailabilityDto> Availabilities { get; set; } = new ();
}

public class AvailabilityDto
{
    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }
}