using System.Collections.Generic;

namespace Registrar.Models
{
  public class Course
  {
    public int CourseId {get; set;}
    public string Name {get; set;}
    public string CourseNumber {get; set;}
    public virtual ICollection<CourseStudent> JoinEntities {get; set;}

    public Course()
    {
      this.JoinEntities = new HashSet<CourseStudent>();
    }
  }
}