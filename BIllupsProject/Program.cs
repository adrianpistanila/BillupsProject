using BIllupsProject.Interfaces;
using BIllupsProject.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IGameService, GameService>();
builder.Services.AddSingleton<IChoiceService, ChoiceService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
