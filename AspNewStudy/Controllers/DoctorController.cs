using AspNewStudy.Models;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNewStudy.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        private HospitalContext hosContext = new HospitalContext();
        private AccountContext accContext = new AccountContext();
        public ActionResult Index()
        {
            return View(hosContext.Patients.ToList());
        }

        [ActionName("Details__Admin")]
        public async Task<ActionResult> Details(int? id)
        {
            var doctor = await hosContext.Doctors.FindAsync(id);

            if (doctor == null)
                return HttpNotFound();


            return View(doctor);
        }


        public ActionResult Create()
        {
   
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Password,EmailD,Gender")]Account docAcc )
        {
            var doc = new Doctor();
            if (String.IsNullOrEmpty(docAcc.Password) ||
                  String.IsNullOrEmpty(docAcc.FirstName) ||
                  String.IsNullOrEmpty(docAcc.LastName) ||
                  String.IsNullOrEmpty(docAcc.Gender) ||
                  String.IsNullOrEmpty(docAcc.EmailD))
            {
                return HttpNotFound("Empty Fields");
            }
            accContext.Accounts.Add(docAcc);

            doc.account = docAcc;
            doc.Id = hosContext.Doctors.Max(d => d.Id) + 1;
            doc.account.ID = accContext.Accounts.Max(acc => acc.ID) + 1;
            doc.account.CreatedDate = DateTime.Now;
           hosContext.Doctors.Add(doc);
           
           hosContext.SaveChanges();
            accContext.SaveChanges();
            return RedirectToAction($"Details/{doc.Id}");
        }

        public ActionResult DoctorPagination(int page = 1)
        {
            int pageSize = 2;

            IQueryable<Doctor> source = hosContext.Doctors;

            var count = source.Count();
            var items = source.OrderBy(acc => acc.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel<Doctor> viewModel = new IndexViewModel<Doctor>
            {
                PageViewModel = pageViewModel,
                Objects = items
            };
            return View(viewModel);
        }


        public ActionResult DoctorFilter(int? patient = null)
        {
            IQueryable<Doctor> filtredDoctors = null;
            IQueryable<Patient> patients = hosContext.Patients;
            IQueryable<Doctor> doctors = hosContext.Doctors;

            if(patient.HasValue && patient != 0)
            {
                filtredDoctors = patients.Where(p => p.Id == patient.Value).
                                  SelectMany(p => p.Doctors);
                ViewBag.docs = filtredDoctors;
            }
            else
            {
                filtredDoctors = doctors;
            }

            var doctorsListView = new IndexListViewModel<Doctor>
            {
                Objects = filtredDoctors,
                Selects = new Hashtable()
                
            };
            doctorsListView.Selects["Patient"] = new SelectList(patients, "Id","account.FirstName");
          
            return View(doctorsListView);
        }


    }
}