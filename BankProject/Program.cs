using BankServices.BankService;
using BankServicesContracts.ServicesContracts;
using System.Globalization;
using BankProject.Middleware;
using BankServicesContracts.RepositoryContracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;
using BankProject;

var builder = WebApplication.CreateBuilder(args);

//Logging
builder.Host.UseSerilog((HostBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfiguration) =>
{
    loggerConfiguration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services);
});

//Adding Services
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
//Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Enviroment 
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseErrorLoggingMiddleware();
    app.UseExceptionHandler("/error");
}

//app.UseExceptionHandlerMiddleware();
app.UseStaticFiles();

app.UseRouting();

//CORS
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


var cultureInfo = new CultureInfo("en-US"); //to to solve the problem of filling numbers in the double format
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

app.Run();
