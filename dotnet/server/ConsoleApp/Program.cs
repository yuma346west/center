// See https://aka.ms/new-console-template for more information

using ConsoleApp.DependencyServices;
using ConsoleApp.DependencyServices.Interface;
using ConsoleApp.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("This is ConsoleApp");

var builder = Host.CreateApplicationBuilder(args);

// add hosted service, Human
builder.Services.AddTransient<Human>();
builder.Services.AddTransient<DayByDay>();

// add scoped MyDateTime service
builder.Services.AddScoped<IDateTimeService, MyDateTime>();
builder.Services.AddScoped<IMath, BasicMath>();

var serviceProvider = builder.Build().Services;

var dayByDay = serviceProvider.GetRequiredService<DayByDay>();
// Console.WriteLine(dayByDay.Calculate());


double a = 99 / 6.5 - 87;
double b = 29 - 107;

var equal = a == b;
var result = a > b;
Console.WriteLine($"answer: {equal} and {result}");


