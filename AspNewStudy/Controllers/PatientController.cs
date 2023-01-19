using AspNewStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNewStudy.Controllers
{
    public class PatientController : Controller
    {
        private HospitalContext context = new HospitalContext();
        public ActionResult Index()
        {
            return View(context.Patients.ToList());
        }

        public async Task<ActionResult> Details(int? id)
        {
            var patient = await context.Patients.FindAsync(id);

            if (patient == null) 
                return  HttpNotFound();


            return View(patient);
        }


    

        public ActionResult Edit(int? id)
        {
            Patient patient = context.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.Doctors = context.Doctors.ToList();

            return View(patient);
        }
        [HttpPost]
        public ActionResult Edit(Patient student, int[] selectedCourses)
        {
            Patient newpatient = context.Patients.Find(student.Id);
            newpatient.account = student.account;

            newpatient.Doctors.Clear();

            if (selectedCourses != null)
            {
                foreach (var doc in context.Doctors.Where(doc => selectedCourses.Contains(doc.Id)))
                {
                    newpatient.Doctors.Add(doc);
                }

            }

            context.Entry(newpatient).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();



            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
                context.Dispose();
            base.Dispose(disposing);
        }
    }
}