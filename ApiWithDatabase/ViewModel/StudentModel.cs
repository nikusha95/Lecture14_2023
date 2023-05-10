namespace ApiWithDatabase.ViewModel;

/// <summary>
/// student model
/// </summary>
public class StudentModel
{
    /// <summary>
    /// student name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// student lastname
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// personal number
    /// </summary>
    public string PersonalId { get; set; }

    /// <summary>
    /// university start year
    /// </summary>
    public int StartYear { get; set; }
}