namespace TimeFrames.Api.Models;

public class DayData
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double WorkTime { get; set; }
    public double WakeTime { get; set; }
    public double SleepTime { get; set; }
    public List<ToDo> Tasks { get; set; }
}