using Blog20190528.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog20190528.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Poster()
        {
            Blog20190528Context db = new Blog20190528Context();

            Post postObj = new Post();
            

            postObj.GetCateList = db.Categories.Select(x => new Post { cateId = x.Id, cateName = x.Name }).ToList();

            return View(postObj);
        }
        [HttpPost]
        public ActionResult Poster(Post objPost)
        {
            //objPost comes to this method with an array of categories, description and title.
            //save desc and title inside th epost table
            // after that save again into a new table you will create with the objPost - Id and loop the objPost array to save with the related post Id

            return RedirectToAction("Poster");
        }
    }
}