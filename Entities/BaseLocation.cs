using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayNirvanaTechExam.Entities;

[Table("Locations")]
public class BaseLocation
{
    [Key]
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Radius { get; set; }
    public virtual ICollection<Place> Places { get; set; }
}