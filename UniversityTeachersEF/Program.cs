using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniversityTeachersEF.Configurations;
using UniversityTeachersEF.Data;
using UniversityTeachersEF.Data.Repositories;
using UniversityTeachersEF.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration.GetConnectionString("MSSQLConnection");
var mapperConfig = new MapperConfiguration(mc =>
    mc.AddProfile(new AutoMapperProfile()));

var mapper = mapperConfig.CreateMapper();

builder.Services
    .AddDbContext<UniversityTeachersDbContext>(options => options.UseSqlServer(connection))
    .AddTransient<ITeacherRepository, TeacherRepository>()
    .AddTransient<IDisciplineRepository, DisciplineRepository>()
    .AddTransient<IHomeAddressRepository, HomeAddressRepository>()
    .AddTransient<IPositionRepository, PositionRepository>()
    .AddTransient<IStreetRepository, StreetRepository>()
    .AddTransient<IWorkPlaceRepository, WorkPlaceRepository>()
    .AddSingleton(mapper)
    .AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();