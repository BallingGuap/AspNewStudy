﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace AspNewStudy.Models
{
    public class Account
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Fill this field")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Too big or small text")]
        [Display(Name = "Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Fill this field")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Too big or small text")]
        [Display(Name = "Surname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Fill this field")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Fill this field")] 
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect input of address")]
        [Display(Name = "Email")]
        public string EmailD { get; set; }

        [Required(ErrorMessage = "Fill this field")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Too big or small text")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
    }
}