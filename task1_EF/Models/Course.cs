using System.ComponentModel.DataAnnotations;

namespace task1_EF.Models
{
    public class Course
    {
        public int CrsId { get; set; }
        public string CrsName { get; set; }
        public virtual ICollection<Department> CoursesDepartments { get; set; }
        public virtual ICollection<StudentCourse> CourceStudents { get; set; }

        public Course()
        {
            CourceStudents = new HashSet<StudentCourse>();
            CoursesDepartments = new HashSet<Department>();
        }
    }
}
