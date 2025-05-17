using BusinessLogic;
using BusinessLogic.Profiles;
using DataAccess;
using DataAccess.UoW;
using Microsoft.AspNetCore.Mvc;
using DTOS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<QuestsContext>();
builder.Services.AddAutoMapper(typeof(QuestProfile).Assembly, typeof(AvailabilityProfile).Assembly);

//register builder.Services
builder.Services.AddScoped<IQuestService, QuestService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/quests", ([FromServices] IQuestService questService) =>
{
    var quests = questService.GetALL();
    return quests;
});

app.MapPost("/quest", ([FromServices] IQuestService questService, [FromBody] QuestDto questDTO) =>
{
    var quest = questService.Create(questDTO);
    return quest;
});


app.MapDelete("/quest", ([FromServices] IQuestService questService, [FromBody] DeleteParams body) =>
{
    var quest = questService.Delete(body.Id);
    return quest;
});


app.Run();