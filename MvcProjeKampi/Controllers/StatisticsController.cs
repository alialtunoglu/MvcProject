using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        public StatisticsService ss = new StatisticsService(new EfCategoryDal(), new EfHeadingDal(),new EfWriterDal());
       
        public ActionResult Index()
        {
            ViewBag.CategoryCount = ss.GetCategoryCount();
            ViewBag.Heading = ss.GetHeadingCountByCategoryName("Yazılım");
            ViewBag.Writer = ss.GetWritersWithA("a");
            ViewBag.HeadingMax = ss.GetCategoryWithMostHeadings();
            ViewBag.StatusDifference = ss.DifferenceStatusCategory();
            return View();
        }
    }
}