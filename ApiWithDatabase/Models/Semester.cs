namespace ApiWithDatabase.Models;

public class Semester
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AvailableGpa { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}