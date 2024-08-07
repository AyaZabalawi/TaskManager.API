using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManager.Core.Domain.Entities;
using TaskManager.Infrastructure.Repositories;
using TaskManager.Core.Application.Services;
using TaskManager.Core.Domain.ServiceContracts;
using TaskManager.Infrastructure;
using TaskManager.Core.Domain.RepositoryContracts;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskManagerAPI", Version = "v1" });
});

// Custom services
builder.Services.AddScoped<IRepository, ItemRepository>();
builder.Services.AddScoped<ITaskAdderService, TaskAdderService>();
builder.Services.AddScoped<ITaskDeleterService, TaskDeleterService>();
builder.Services.AddScoped<ITaskUpdaterService, TaskUpdaterService>();
builder.Services.AddScoped<ITaskGetterService, TaskGetterService>();

var app = builder.Build();

// HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); 
}

// Middleware configuration
app.UseHttpsRedirection();
app.UseStaticFiles(); 
app.UseRouting();
app.UseAuthorization();

// Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManagerAPI V1");
});

app.MapControllers();

app.Run();
