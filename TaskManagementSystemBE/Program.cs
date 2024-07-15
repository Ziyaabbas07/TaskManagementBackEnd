using DataLayer.ApplicationDbContext;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs.Requests;
using ServiceLayer.IServices;
using ServiceLayer.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("TaskManagementSystemBE")));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<SignUpRequestValidator>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITeamService, TeamService>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<ITaskAttachmentService, TaskAttachmentService>();
builder.Services.AddTransient<ITasksNoteService, TasksNoteService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "myCors",
    builder =>
    {
        builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("myCors");
app.MapControllers();

app.Run();
