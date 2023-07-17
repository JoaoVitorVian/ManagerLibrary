using Manager.Infra.Interfaces;
using Manager.Infra.Repositories;
using Manager.Services.Services;
using Manager.Services.Interfaces;
using AutoMapper;
using Manager.Services.DTO;
using Manager.Domain.Entities;
using ManagerAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Manager.Infra.Context;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AutoMapperConfig

#region DependencyInjection
builder.Services.AddDbContext<ManagerContext>(options =>options.UseSqlServer("Data Source=DESKTOP-LJU8U6L\\SQLEXPRESS;Initial Catalog=USERMANAGERAPI;Integrated Security=True;TrustServerCertificate=True"),ServiceLifetime.Transient);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ILibraryService, LibraryService>();
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
#endregion
var autoMapperConfig = new MapperConfiguration(cfg =>{
    cfg.CreateMap<User, UserDTO>().ReverseMap();
    cfg.CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();

    cfg.CreateMap<Library, LibraryDTO>().ReverseMap();
    cfg.CreateMap<CreateLibraryViewModel, LibraryDTO>().ReverseMap();
});	

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());
#endregion

var app = builder.Build();

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
