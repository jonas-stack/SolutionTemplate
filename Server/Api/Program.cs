using DataAccess;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddOpenApiDocument();
builder.Services.AddDbContext<MyDbContext>(Options =>
{
    //Options.UseSqlite("Data Source=../DataAccess/mydatabase.db");
    Options.UseNpgsql(builder.Configuration.GetConnectionString("MyDbConn"));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>(); // Ensure MyDbContext is retrieved
    dbContext.Database.EnsureCreated();
}

app.MapControllers();
app.UseOpenApi();
app.UseSwaggerUi();

app.UseCors(opts => {
    opts.AllowAnyOrigin();
    opts.AllowAnyMethod();
    opts.AllowAnyHeader();
});

app.Run();


