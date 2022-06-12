using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using task1_EF.Data;
using task1_EF.Models;
using System;
using System.IO;

namespace task1_EF.Controllers
{
    public class StdController : Controller
    {
        ITIDbContext db = new ITIDbContext();
        public IActionResult Index()
        {
            return View(db.Students.Include(a => a.Department).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.depts = new SelectList(db.Departments.ToList(), "DeptId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student std, IFormFile StdImg)
        {
            if (StdImg == null)
                ModelState.AddModelError("StdImg", "image is required");
            if(ModelState.IsValid)
            {
                db.Students.Add(std);
                db.SaveChanges();
                string[] arr = StdImg.FileName.Split('.');
                string filename = std.Id.ToString() + "." + arr[arr.Length - 1];
                using (var fs = new FileStream("./wwwroot/images/" + filename, FileMode.Create))
                {
                    StdImg.CopyTo(fs);
                }
                std.StdImg = filename;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.depts = new SelectList(db.Departments.ToList(), "DeptId", "Name", std.DeptNo);
            return View(std);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            Student std = db.Students.Include(a => a.Department).SingleOrDefault(d => d.Id == id);
            if(std is null)
                return NotFound();
            return View(std);
        }

        public IActionResult Delete(int? id)
        { 
            if (id == null)
                return NotFound();
            Student std = db.Students.Include(a => a.Department).SingleOrDefault(d => d.Id == id);
            if(std is null)
                return NotFound();
            return View(std);
        }

        [ActionName("Delete")]
        [HttpPost]
        public IActionResult DeleteAction(int id)
        {
            Student std = db.Students.Include(a => a.Department).SingleOrDefault(d => d.Id == id);
            db.Students.Remove(std);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Student std = db.Students.Include(a => a.Department).SingleOrDefault(d => d.Id == id);
            ViewBag.depts = new SelectList(db.Departments.ToList(), "DeptId", "Name", std.DeptNo);
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit(Student std)
        {
            if (ModelState.IsValid)
            {
                db.Students.Update(std);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.depts = new SelectList(db.Departments.ToList(), "DeptId", "Name", std.DeptNo);
            return View(std);
        }

        public IActionResult CheckUserName(string UserName, int Id=0)
        {
            Student std = db.Students.Where(a => a.Id != Id).SingleOrDefault(d => d.UserName == UserName);
            if (std == null)
                return Json(true);
            else
                return Json(false);
        }

        public IActionResult EditImg(int id)
        {
            Student std = db.Students.SingleOrDefault(d => d.Id == id);
            return View(new ImageViewModel() { Id = std.Id, StdImg = std.StdImg });
        }

        [HttpPost]
        public IActionResult EditImg(int id, IFormFile StdImg)
        {
            Student std = db.Students.SingleOrDefault(d => d.Id == id);
            if (StdImg == null)
                ModelState.AddModelError("StdImg", "image is required");
            if (ModelState.IsValid)
            {
                string[] arr = StdImg.FileName.Split('.');
                string filename = std.Id.ToString() + "." + arr[arr.Length - 1];
                string pathImg = "./wwwroot/images/" + filename;
                //File.Delete(pathImg);
                using (var fs = new FileStream(pathImg, FileMode.Truncate))
                {
                    StdImg.CopyTo(fs);
                }
                std.StdImg = filename;
                db.SaveChanges(); 
                return RedirectToAction("Details", "Std" , new {id});
            }
            return View(new ImageViewModel() { Id=std.Id, StdImg=std.StdImg });
        }

        public IActionResult EditPassword(int id)
        {
            Student std = db.Students.SingleOrDefault(d => d.Id == id);
            return View(new PasswordViewModel() { Id = std.Id, Password = std.Password, UserName = std.UserName });
        }

        [HttpPost]
        public IActionResult EditPassword(PasswordViewModel passModel)
        {
            Student std = db.Students.SingleOrDefault(d => d.Id == passModel.Id);
            if (ModelState.IsValid)
            {
                std.Password = passModel.Password;
                std.UserName = passModel.UserName;
                db.SaveChanges();
                return RedirectToAction("Details", "Std", new { passModel.Id });
            }
            return View(new PasswordViewModel() { Id = std.Id, Password = std.Password, UserName = std.UserName });
        }
    }
}
