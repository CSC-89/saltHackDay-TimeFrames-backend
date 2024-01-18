using Microsoft.Build.Framework;

namespace TimeFrames.Api.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    public List<DayData> Dates { get; set; }
}