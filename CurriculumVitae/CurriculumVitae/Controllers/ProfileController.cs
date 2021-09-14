using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CurriculumVitae.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Bio()
        {
            ViewBag.Name = "Nusrat Jahan";
            ViewBag.Summery = "I am a mobile application developer with qualifications and experiences. Before my graduation when I completed the course of software engineering I decided to proceed with that. Always I want to stay updated with all technological changes so that I can offer better ideas based on situation. I used to discuss about mobile application developing with different developers which helps me to know more about this industry.";
            ViewBag.Details = "Personal Details";
            ViewBag.FatherName = "Md.Nizam Uddin";
            ViewBag.MotherName = "Momotaj Begum";
            ViewBag.Address = "House-12, Road-9, Sector-6, Mirpur, Dhaka";
            ViewBag.Email = "nusrat@gmail.com";
            ViewBag.DOB = "26 March 1994";

            return View();
        }

        public ActionResult Education()
        {
            ViewBag.Y1 = "2018-2020";
            ViewBag.Y2 = "2014-2018";
            ViewBag.Y3 = "2012-2014";
            ViewBag.Y4 = "2010-2012";
            ViewBag.Institution1 = "American International University Bangladesh";
            ViewBag.Institution2 = "Siddheswari Girls’ College";
            ViewBag.Institution3 = "Motijheel Govt Girls’ High School";
            ViewBag.Department1 = "Computer Science & Engineering(MSc)";
            ViewBag.Department2 = "Computer Science & Engineering(BSc)";
            ViewBag.Division1 = "Science";
            ViewBag.Division2 = "Science";

            return View();
        }

        public ActionResult Projects()
        {
            ViewBag.Project1 = "Library Management System";
            ViewBag.Project2 = "Foodcourt Management System";
            ViewBag.Project3 = "Supershop Management System";
            ViewBag.Project4 = "Space Renting";
            ViewBag.Project5 = "Online Bus Ticketing System";
            return View();
        }

        public ActionResult References()
        {
            ViewBag.Name1 = "-Mr Dip Nandi, Professor, American International University Bangladesh";
            ViewBag.Email1 = "dipnandi@aiub.edu";
            ViewBag.Name2 = "-Tanvir Ahmed, Lecturer, American International University Bangladesh ";
            ViewBag.Email2 = "tanvir.ahmed@aiub.edu";
            return View();
        }

    }
}