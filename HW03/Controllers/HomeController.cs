using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HW03.Models;

namespace HW03.Controllers
{
    public class HomeController : Controller
    {
        private readonly FileModel fileModel = new FileModel();

        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Home(HttpPostedFileBase files, string filetype)
        {
            System.Diagnostics.Debug.WriteLine(filetype);
            System.Diagnostics.Debug.WriteLine(files);
            if (files != null)
            {
                var fileName = System.IO.Path.GetFileName(files.FileName);

                if (filetype == "Document")
                {
                    // store the file inside ~/Media/Documents folder
                    var path = Path.Combine(Server.MapPath("~/Media/Documents/"), fileName);
                    // The chosen default path for saving
                    files.SaveAs(path);
                }
                else if (filetype == "Image")
                {
                    // store the file inside ~/Media/Images folder
                    var path = Path.Combine(Server.MapPath("~/Media/Images/"), fileName);
                    // The chosen default path for saving
                    files.SaveAs(path);
                }
                else
                {
                    // store the file inside ~/Media/Videos folder
                    var path = Path.Combine(Server.MapPath("~/Media/Videos/"), fileName);
                    // The chosen default path for saving
                    files.SaveAs(path);
                }
            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("Home");
        }

        public ActionResult AboutMe()
        {
            return View();
        }
    }
}