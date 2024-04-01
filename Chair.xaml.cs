using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherInformationSystem.Models
{
    public class Chair
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Faculty")]
        public int IdFaculty { get; set; }

        public string NameChair { get; set; }

        public string ShortNameChair { get; set; }

        public virtual Faculty Faculty { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
