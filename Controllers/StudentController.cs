using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Jquery.Data;
using Student_Jquery.Models;
using System.Security.Cryptography.X509Certificates;

namespace Student_Jquery.Controllers
{
    public class StudentController : Controller
    {

        private StudentDAL studentDAL = null;

        public StudentController()
        {
            studentDAL = new StudentDAL();
        }

        // GET: StudentController
        public ActionResult Index()
        {
            IEnumerable<Student> students = studentDAL.GetAllStudent();
            return View(students);

        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            Student student = studentDAL.GetStudentData(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult GetDetailsById(int id)
        {
            Student student = studentDAL.GetStudentData(id);
            return Json(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        
        public ActionResult Create(Student student)
        {
            Console.WriteLine("hello");
            try
            {
                studentDAL.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }


        }

        public ActionResult CreateOrEdit()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]

        public ActionResult CreateOrEdit(Student student)
        {
            Console.WriteLine("hello");
            try
            {
                studentDAL.AddOrEditStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }


        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = studentDAL.GetStudentData(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                studentDAL.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = studentDAL.GetStudentData(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student student)
        {
            try
            {
                studentDAL.DeleteStudent(student.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
       
        public ActionResult DeleteStu(Student student)
        {
            try
            {
                studentDAL.DeleteStudent(student.Id);
                return Json(student);
            }
            catch
            {
                return Json(student);
            }
        }
    }
}
