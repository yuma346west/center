using System.Diagnostics.CodeAnalysis;
using ConsoleApp.DependencyServices.Interface;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsoleApp.Services;

public class DayByDay : BackgroundService
{
    private ILogger<DayByDay> Logger { get; }
    // IMath Interface
    private IMath MyMath { get; }

    public DayByDay(ILogger<DayByDay> logger, IMath myMath)
    {
        Logger = logger;
        MyMath = myMath;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1_000, stoppingToken);
        }
    }

    public int Calculate()
    {
        MyMath.Calculate();
        return MyMath.Current();
    }
    
    public void GreatestCommonDivisor(int num) {
        var a = 60;
        
        num = Math.Abs(num);

        var small = Math.Min(a, num);
        var large = Math.Max(a, num);

        var remainder = large % small;
        var prev = 0;
        while (remainder != 0) {
            remainder = large % small;
            large = small;
            small = remainder;
            if (prev == remainder) {
                break;
            }

            prev = remainder;
        }

        var saidaikouyakusu = large;

        if (saidaikouyakusu != 4) {
            return;
        }
        
        var saisyokobaisu = a * num / saidaikouyakusu;

        Console.WriteLine($"{num} {saidaikouyakusu} {saisyokobaisu}");
        if (saisyokobaisu != 780) {
            return;
        }
        Console.WriteLine($"saidaikouyakusu {saidaikouyakusu}");
        Console.WriteLine($"saisyokobaisu {saisyokobaisu}");
    }
}