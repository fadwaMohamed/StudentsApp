using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task1_EF.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        // by default lazy load
        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Course> DepartmentCourses { get; set; }

        public Department()
        {
            // hashset > to prevent repeat in list
            Students = new HashSet<Student>();
            DepartmentCourses = new HashSet<Course>();
        }
    }
}
