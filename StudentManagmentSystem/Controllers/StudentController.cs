using Microsoft.AspNetCore.Mvc;
using StudentManagmentSystem.Models;

namespace StudentManagmentSystem.Controllers
{
    public class StudentController : Controller
    {
        StudentContext context=new StudentContext();
        [HttpGet]
        public IActionResult index()
        {
            return View("home");
        }
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            List<Student> students = context.Student.ToList();

            return View("GetAllStudents", students);
        }

        [HttpGet]
        public IActionResult Add()
        {
           
            return View("AddStudent");
        }
        [HttpPost]
        public IActionResult AddNewStudent(Student studentFromReq)
        {

            if (studentFromReq.Name != null
                && studentFromReq.Email != null
                && studentFromReq.Password != null
                && studentFromReq.Phone != null
                && studentFromReq.ClassLevel != null
                )
            {
                try
                {

                    context.Student.Add(studentFromReq);
                    context.SaveChanges();
                    return RedirectToAction("index");
                }
                catch (Exception ex)
                {
                    return Content("there  are error in db");
                }
            }

           
            return View("AddStudent", studentFromReq);
        }
        [HttpGet]
        public IActionResult Edit(int id) {
            Student student = context.Student.FirstOrDefault(e => e.Id == id);
            if (student == null)
            {
                return RedirectToAction("index");
            }
            return View("EditStudent", student);
        }
        [HttpPost]
        public IActionResult SaveEditStudent(Student studentFromReq, int id) {
            if (studentFromReq.Name != null
                && studentFromReq.Email != null
                && studentFromReq.Password != null
                && studentFromReq.Phone != null
                && studentFromReq.ClassLevel != null

                )
            {
                Student studentFromDb = context.Student.FirstOrDefault(e => e.Id == id);
                if (studentFromDb != null)
                {
                    try
                    {
                        studentFromDb.Name = studentFromReq.Name;
                        studentFromDb.Email = studentFromReq.Email;
                        studentFromDb.Password = studentFromReq.Password;
                        studentFromDb.Phone = studentFromReq.Phone;
                        studentFromDb.ClassLevel = studentFromReq.ClassLevel;
                        context.SaveChanges();
                        return RedirectToAction("index");
                    }
                    catch (Exception ex)
                    {
                        return Content("there are problem in db");
                    }

                }
                return NotFound(id);
            }                    
            return View("EditStudent", studentFromReq);
        }

    }
}
