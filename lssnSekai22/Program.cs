using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CollegeAPI.Data;
using CollegeAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CollegeDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.MapGet("/students/all", async (CollegeDBContext db) => 
    await db.Students.Include(s => s.Group).ToListAsync());

app.MapGet("/groups/all", async (CollegeDBContext db) => 
    await db.Groups.Include(g => g.Students).ToListAsync());

app.MapPost("/students/add", async (Student student, CollegeDBContext db) => {
    db.Students.Add(student);
    await db.SaveChangesAsync();
    return Results.Created($"/students/{student.Id}", student);
});

app.MapPost("/groups/add", async (Group group, CollegeDBContext db) => {
    db.Groups.Add(group);
    await db.SaveChangesAsync();
    return Results.Created($"/groups/{group.Id}", group);
});

app.MapPut("/students/{id}", async (int id, Student inputStudent, CollegeDBContext db) => {
    var student = await db.Students.FindAsync(id);
    if (student == null) return Results.NotFound();
    student.FirstName = inputStudent.FirstName;
    student.LastName = inputStudent.LastName;
    student.Age = inputStudent.Age;
    student.GroupId = inputStudent.GroupId;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/students/{id}", async (int id, CollegeDBContext db) => {
    var student = await db.Students.FindAsync(id);
    if (student == null) return Results.NotFound();
    db.Students.Remove(student);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
