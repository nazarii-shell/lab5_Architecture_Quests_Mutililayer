using System.ComponentModel.DataAnnotations.Schema;
namespace DataAccess.Models;

public class Quest
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int ParticipantsLimit { get; set; }

    // Navigation Property
    public List<Availability> Availabilities { get; set; } = new ();
}