using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherInformationSystem.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Chair")]
        public int IdChair { get; set; }

        [ForeignKey("Post")]
        public int IdPost { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
