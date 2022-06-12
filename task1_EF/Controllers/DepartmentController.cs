using Microsoft.AspNetCore.Mvc;
using task1_EF.Data;
using task1_EF.Models;

namespace task1_EF.Controllers
{
    public class DepartmentController : Controller
    {
        ITIDbContext db = new ITIDbContext();
        public IActionResult Index()
        {
            return View(db.Departments.ToList());
        }

        public IActionResult Create()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Create(Department dept)
        {
            if(db.Departments.SingleOrDefault(d => d.DeptId == dept.DeptId) == null)
            {
                db.Departments.Add(dept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult Edit(int DeptId)
        {
            Department dept = db.Departments.SingleOrDefault(d => d.DeptId == DeptId);
            return View(dept);
        }

        [HttpPost]
        public IActionResult Edit(Department dept)
        {
            db.Departments.Update(dept);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int DeptId)
        {
            Department dept = db.Departments.SingleOrDefault(d => d.DeptId == DeptId);
            return View(dept);
        }

        [ActionName("Delete")]
        [HttpPost]
        public IActionResult DeleteAction(int DeptId)
        {
            Department dept = db.Departments.SingleOrDefault(d => d.DeptId == DeptId);
            db.Departments.Remove(dept);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
