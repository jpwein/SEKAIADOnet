using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSekaiADOGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSekaiADO();
    app.UseSekaiADOUI(c =>
    {
        c.RoutePrefix = "sekaiADO";
        c.SekaiADOEndpoint("/sekaiADO/v1/sekaiADO.json", "College API v1");
    });
}

app.UseStaticFiles();

app.MapGet("/students/all", () => new[] 
{ 
    new { Id = 1, FirstName = "Иван", LastName = "Иванов", Age = 20, GroupId = 1 } 
});

app.MapGet("/groups/all", () => new[] 
{ 
    new { Id = 1, Name = "ПИ-21" } 
});

app.MapPost("/students/add", (object student) => Results.Created("/students/1", student));
app.MapPut("/students/{id}", (int id, object student) => Results.NoContent());
app.MapDelete("/students/{id}", (int id) => Results.NoContent());

app.Run();
