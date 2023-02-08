using AspNewStudy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNewStudy.Controllers
{
    public class PatientController : Controller
    {
        private HospitalContext hosContext = new HospitalContext();
        private AccountContext accContext = new AccountContext();
        public ActionResult Index()
        {
            return View(hosContext.Patients.ToList());
        }

        public async Task<ActionResult> Details(int? id)
        {
            var patient = await hosContext.Patients.FindAsync(id);

            if (patient == null) 
                return  HttpNotFound();


            return View(patient);
        }


    

        public async Task<ActionResult> Edit(int? id)
        {
            Patient patient = await hosContext.Patients.FindAsync(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.Doctors = hosContext.Doctors.ToList();

            return View(patient);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Patient patient, [Bind(Include = "FirstName, Password")] Account account ,int[] selectedCourses)
        {
            Patient newpatient = await hosContext.Patients.FindAsync(patient.Id);
            newpatient.account = accContext.Accounts.FirstOrDefault(acc => acc.FirstName == account.FirstName && 
                                                                           acc.Password == account.Password);
            if (newpatient.account == null)
                return HttpNotFound("Wrong Password or Login");


            newpatient.Doctors.Clear();

            if (selectedCourses != null)
            {
                foreach (var doc in hosContext.Doctors.Where(doc => selectedCourses.Contains(doc.Id)))
                {
                    newpatient.Doctors.Add(doc);
                }

            }

            hosContext.Set<Patient>().AddOrUpdate(newpatient);

            hosContext.SaveChanges();


            //return account.FirstName + " " + account.Password;
            return RedirectToAction($"Details/{patient.Id}");
        }

        public  ActionResult FindPatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindPatient(string patientName)
        {
            var patient = hosContext.Patients.FirstOrDefault(p => p.account.FirstName == patientName);
            return patient != default(Patient) 
                ? RedirectToAction($"Details/{patient.Id}") 
                : throw new NullReferenceException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                hosContext.Dispose();
            base.Dispose(disposing);
        }
    }
}