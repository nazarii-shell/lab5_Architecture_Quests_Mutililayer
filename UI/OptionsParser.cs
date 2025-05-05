using BusinessLogic;

namespace UI;

public class OptionsParser
{
    private Pages _pages;
    public OptionsParser(Pages pages)
    {
        _pages = pages;   
    }
    public void ParseOption(Option request)
    {
        Console.Clear();
        switch (request.Method)
        {
            case "GET":
                switch (request.URl)
                {
                    case "quest":
                        _pages.SearchQuests();
                        break;
                }

                break;
            case "PUT":
                switch (request.URl)
                {
                    case "bookQuest":
                        _pages.BookQuest();
                        break;
                }
                break;
        }
    }
}