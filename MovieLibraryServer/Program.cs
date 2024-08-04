using MovieLibraryServer.Infrastructure.Extensions.StartupExtensions;
using MovieLibraryServer.Infrastructure.Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptions(builder.Configuration);
builder.Services.AddDbContext<MovieLibraryDataContext>();
builder.Services.AddMediator();
builder.Services.AddRepositories();
builder.Services.AddClients();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");
app.Run();
