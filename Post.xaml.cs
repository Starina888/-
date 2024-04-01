using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeacherInformationSystem.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string NamePost { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
