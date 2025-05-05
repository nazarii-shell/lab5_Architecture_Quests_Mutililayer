namespace UI;

public class Menu
{
    static public Option GetOption()
    {
        var options = OptionsCreator.CreateOptions();

        Console.WriteLine("Choose an option: ");

        for (int i = 0; i < options.Count; i++)
        {
            var option = options[i];
            Console.WriteLine($"{i}) {option.Text}");
        }
        
        var answer = int.Parse(Console.ReadLine());
        
        return options[answer];
    }
}