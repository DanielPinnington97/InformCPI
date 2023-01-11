using FluentValidation.AspNetCore;
using InformCPISolution.Data;
using Microsoft.EntityFrameworkCore;
using InformCPISolution.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{ 
});

builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

builder.Services.AddDbContext<InformCPIDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InformCPI"));
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFluentValidationAutoValidation();

// Register startup
StartupConfiguration.RegisterRepositories(builder.Services);
StartupConfiguration.RegisterServices(builder.Services, builder.Configuration);

// Register swagger
SwaggerConfiguration.SetupSwagger(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.Run();
