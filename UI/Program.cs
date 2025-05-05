using BusinessLogic;
using BusinessLogic.Profiles;
using DataAccess.UoW;
using DataAccess;
using Microsoft.Extensions.DependencyInjection;
using UI;

var context = new QuestsContext();
var services = new ServiceCollection();
services.AddDbContext<QuestsContext>();
services.AddAutoMapper(typeof(QuestProfile).Assembly);

//register services
services.AddScoped<IQuestService, QuestService>();
services.AddScoped<IUnitOfWork, UnitOfWork>();

services.AddScoped<ConsoleUI>();

var serviceProvider = services.BuildServiceProvider();
var console = serviceProvider.GetRequiredService<ConsoleUI>();
console.Run();