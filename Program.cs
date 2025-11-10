// ---------------------------------------------------------
// File: Program.cs
// Description: This file is the main starting point of the app.
// It connects everything together — database, pages, settings, 
// and the way the app runs in different environments.
// Author: Cindy Johana Caicedo
// ---------------------------------------------------------
using JobTrackerApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------------------------------------
// 1) Add the main services that the app needs to work
// ---------------------------------------------------------

// Enables documentation for the API (OpenAPI)

builder.Services.AddOpenApi();

// Connects the app to the SQL Server database using the connection details in appsettings.json
builder.Services.AddDbContext<JobTrackerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CommanderConnection")));

// Sets up the pages and controllers, and makes sure the data looks clean and easy to read (camelCase)
builder.Services
    .AddControllersWithViews()
    .AddNewtonsoftJson(s =>
    {
        s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    });

// Lets the app automatically match information between different objects (like models and DTOs)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Connects the app to your database actions (save, edit, delete)
builder.Services.AddScoped<IJobApplicationRepository, SqlJobApplicationRepo>();

var app = builder.Build();

// ---------------------------------------------------------
// 2) Handle errors differently depending on where the app runs
// ---------------------------------------------------------

if (app.Environment.IsDevelopment())
{
    // When running on your computer, show detailed errors for easier fixing
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
}
else
{
    // When running online, show a simple, friendly error page
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ---------------------------------------------------------
// 3) Set up files, routes, and how the pages are displayed
// ---------------------------------------------------------

// Allows the app to show images, CSS, and other static files
app.UseStaticFiles();

// Sets up navigation between pages and controllers
app.UseRouting();

// Activates all API routes (like /api/jobapplications)
app.MapControllers();

// Defines the main website route (default page)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=JobApplicationUi}/{action=Index}/{id?}");

// Starts the web app
app.Run();
