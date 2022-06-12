using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task1_EF.Data;
using task1_EF.Models;

namespace task1_EF.Controllers
{
    public class StudentController : Controller
    {
        ITIDbContext db = new ITIDbContext();

        public IActionResult Work1()
        {
            Department dept = db.Departments.SingleOrDefault(d => d.DeptId == 1);
            // add student in dept 2
            Student std = new Student() { Name="alaa", Age=25, DeptNo= 2 };
            db.Students.Add(std);
            db.SaveChanges();

            // change department of the student
            dept.Students.Add(std);
            db.SaveChanges();

            return Content("Added");
        }
        public IActionResult Work2()
        {
            // get student without department (lazy load)
            db.Students.SingleOrDefault(a => a.Id == 1);
            // get department with dapartment (eager load)
            db.Students.Include(a => a.Department).SingleOrDefault(a => a.Id == 1);

            return Content("Data");
        }
        public IActionResult Work3()
        {
            // add student course
            Student std = db.Students.SingleOrDefault(a => a.Id == 1);
            Course crs = db.Courses.SingleOrDefault(a => a.CrsId == 1);
            crs.CourceStudents.Add(new StudentCourse() { Student = std });
            db.SaveChanges();

            db.StudentCourses.Add(new StudentCourse() { CrsId = 2, StdId = 2 });
            db.SaveChanges();

            return Content("Added");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
