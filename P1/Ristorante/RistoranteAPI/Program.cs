using Logic;
using RateAppDL;



//const string connectionStringFilePath = "../../../../DL/connection-string.txt";
//string connectionString;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository>(repo => new SqlRepository());
builder.Services.AddScoped<ILogic, Operations>();

var app = builder.Build();
app.Logger.LogInformation("App Started");

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
