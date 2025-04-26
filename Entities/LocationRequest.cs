using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayNirvanaTechExam.Entities;

[Table("Locations")]
public class LocationRequest : BaseEntity
{
    [Key]
    public int Id { get; set; }
  
    public virtual ICollection<Place> Places { get; set; }
}