using System.ComponentModel.DataAnnotations.Schema;

namespace task1_EF.Models
{
    public class StudentCourse
    {
        [ForeignKey("Student")]
        public int StdId { get; set; }

        [ForeignKey("Course")]
        public int CrsId { get; set; }
        public int Degree { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }

    }
}
