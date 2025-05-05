using BusinessLogic;

namespace UI;

public class Pages
{
    private readonly IQuestService _questService;

    public Pages(IQuestService questService)
    {
        _questService = questService;
    }

    public void SearchQuests()
    {
        Console.WriteLine("Enter your search query: ");
        var query = Console.ReadLine();
        var quests = _questService.Find(query);
        foreach (var quest in quests)
        {
            Console.WriteLine(quest);
        }
    }

    public void BookQuest()
    {
        Console.WriteLine("Enter quest ID: ");
        var id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter people count: ");
        var people_count = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter your time: ");
        var time = TimeOnly.Parse(Console.ReadLine());

        Console.WriteLine("Do you have gitf card: y/n");
        var haveGiveCard = Console.ReadLine().ToLower() == "y" ? true : false;

        try
        {
            var quest = _questService.Book(id, time, people_count, haveGiveCard);

            if (quest.Price != 0)
            {
                Console.WriteLine($"Quest {quest.Name} was booked. Cost is ${quest.Price}");
            }
            else
            {
                Console.WriteLine($"Quest {quest.Name} was booked. Cost is $0");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}