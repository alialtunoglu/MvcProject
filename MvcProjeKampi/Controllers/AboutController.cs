﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var aboutValues = abm.GetList();
            return View(aboutValues);
        }
        public ActionResult AddAbout(About p )
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial() 
        {
            return PartialView();
        }
        public ActionResult DeleteAbout(int id)
        {
            var aboutValue = abm.GetById(id);
            aboutValue.AboutStatus = !aboutValue.AboutStatus; // Durumu tersine çevir.
            abm.AboutDelete(aboutValue);
            return RedirectToAction("Index");
        }

    }
}