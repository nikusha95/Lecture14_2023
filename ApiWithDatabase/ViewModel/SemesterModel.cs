namespace ApiWithDatabase.ViewModel;

public class SemesterModel
{
    /// <summary>
    /// semester description
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// available gpa in semester
    /// </summary>
    public int AvailableGpa { get; set; }
    /// <summary>
    /// semester start date
    /// </summary>
    public DateTime StartDate { get; set; }
    /// <summary>
    /// semester end date
    /// </summary>
    public DateTime EndDate { get; set; }
}