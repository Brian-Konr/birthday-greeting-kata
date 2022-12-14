using BirthdayGreetingKataService.DataProviders;
using BirthdayGreetingKataService.GreetingMessageGenerators;
using BirthdayGreetingKataService.ResultGenerators;
using BirthdayGreetingKataService.Results;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IDataProvider, PostgreSqlDataProvider>();
builder.Services.AddSingleton<IDataProvider, MongoDBDataProvider>();

builder.Services.AddSingleton<IGreetingMessageGenerator, GreetingMessageGeneratorVer1>();
//builder.Services.AddSingleton<IGreetingMessageGenerator, GreetingMessageGeneratorVer2>();
//builder.Services.AddSingleton<IGreetingMessageGenerator, GreetingMessageGeneratorVer3>();
//builder.Services.AddSingleton<IGreetingMessageGenerator, GreetingMessageGeneratorVer4>();

// inject ResultGenerator
builder.Services.AddSingleton<IResultGenerator, XmlResultGenerator>();
//builder.Services.AddSingleton<IResultGenerator, JsonResultGenerator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
