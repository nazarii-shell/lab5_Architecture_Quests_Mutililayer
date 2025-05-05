namespace UI;

public class OptionsCreator
{
    static public List<Option> CreateOptions()
    {
        List<Option> options = new List<Option>
        {
            new Option(RequestMethods.GET, "quest", "Search quest"),
            new Option(RequestMethods.PUT, "bookQuest", "Book quest")
        };
        return options;
    }
}