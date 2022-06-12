using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task1_EF.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(20, 30)]
        public int Age { get; set; }
        public string StdImg { get; set; }

        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z0-9]+.[a-zA-Z0-9]+")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        public string CPassword { get; set; }

        [Required]
        [Remote("CheckUserName", "Std")]
        public string UserName { get; set; }

        [ForeignKey("Department")]
        public int DeptNo { get; set; }

        public Department Department { get; set; }
        public virtual ICollection<StudentCourse> studentCources { get; set; }

        public Student()
        {
            studentCources = new HashSet<StudentCourse>();
        }
    }
}
