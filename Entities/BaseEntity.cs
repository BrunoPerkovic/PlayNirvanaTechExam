namespace PlayNirvanaTechExam.Entities;

public abstract class BaseEntity
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime StartedDate { get; set; }
    public DateTime CreatedDate { get; set; }
}