namespace TimeFrames.Api.Models;

public class ToDo
{
    public int Id { get; set; }
    public string Content { get; set; }
    public string TaskType { get; set; }
    public int  CompletionTime { get; set; }
    public string TypeColor { get; set; }
}