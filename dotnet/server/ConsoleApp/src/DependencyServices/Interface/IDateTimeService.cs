namespace ConsoleApp.Services.Interface;

public interface IDateTimeService
{
    public DateTime UtcNow();
    
    // method. DateTIme Diff
    public TimeSpan Diff(DateTime start, DateTime end);
}