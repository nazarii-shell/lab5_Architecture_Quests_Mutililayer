using BusinessLogic;
using BusinessLogic.Models;

namespace UI
{
    internal class ConsoleUI
    {
        private readonly IQuestService _questService;

        public ConsoleUI(IQuestService questService)
        {
            _questService = questService;
        }

        public void Run()
        {
            var pages = new Pages(_questService);
            var optionParser = new OptionsParser(pages);
            var option = Menu.GetOption();
            optionParser.ParseOption(option);
        }
    }
}