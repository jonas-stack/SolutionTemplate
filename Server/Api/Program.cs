var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddOpenApiDocument();

var app = builder.Build();

app.MapControllers();
app.UseOpenApi();
app.UseSwaggerUi();

app.UseCors(opts => {
    opts.AllowAnyOrigin();
    opts.AllowAnyMethod();
    opts.AllowAnyHeader();
});

app.Run();


