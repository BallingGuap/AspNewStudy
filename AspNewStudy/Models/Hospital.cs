using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNewStudy.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public Account account { get; set; }
        public virtual ICollection<Doctor> Doctors{ get; set; }
        public Patient() 
            => Doctors = new List<Doctor>();
      
    }

    public class Doctor 
    {
        public int Id { get; set; }
        public Account account { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }

        public Doctor() =>
            Patients = new List<Patient>();
    }



}