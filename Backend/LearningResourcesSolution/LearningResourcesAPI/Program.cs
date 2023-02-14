using LearningResourcesAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS!! Cross-Origin Resource Sharing! (ex localhost:4200 sending request to localhost:1337)
builder.Services.AddCors(pol =>
{
    pol.AddDefaultPolicy(p =>
    {
        p.AllowAnyOrigin();
        p.AllowAnyMethod();
        p.AllowAnyHeader();
    });
});

builder.Services.AddSingleton<ISystemTime, SystemTime>(); //<abstract class, implementation>

var app = builder.Build();

//use cors
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers(); // created the route table

// above this is configuration
app.Run(); //Blocking call - the api is the up and running
