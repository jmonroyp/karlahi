var builder = WebApplication.CreateBuilder(args);
using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "KarlArt.Core.Api",
        Version = builder.Configuration["Version"],
        Description = "KarlArt.Core.Api",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "KarlArt - Exposición de Arte",
            Email = "jonathan.d.monroy@gmail.com",
            Url = new Uri("https://www.facebook.com")
        }
    });
    c.EnableAnnotations();
});
builder.Services.AddLogging();
builder.Services.AddAuthorization();
builder.Services.AddInfrastructureServices(builder, loggerFactory!.CreateLogger("Infrastructure"));
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.GenerateRequestExamples();
    app.UseStaticFiles();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.UseMinimalApi();

app.Run();

