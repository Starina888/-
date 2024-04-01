using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeacherInformationSystem.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }

        public string NameFaculty { get; set; }

        public string ShortNameFaculty { get; set; }

        public virtual ICollection<Chair> Chairs { get; set; }
    }
}
