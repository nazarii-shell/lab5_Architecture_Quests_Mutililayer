using System.ComponentModel.DataAnnotations.Schema;
namespace DataAccess.Models;

public class Availability
{
    public int Id { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    // Foreign Key
    public int QuestId { get; set; }

    // Navigation Property
    public Quest Quest { get; set; }
}