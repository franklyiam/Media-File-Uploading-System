using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HW03.Models;

namespace HW03.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Video()//function that creates a list of directories and uses them in the view
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Videos/"));
            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);
        }

        public FileResult DownloadFile(string filename) //allows the user to download a file from /Media/Videos/
        {
            string filePath = Server.MapPath("~/Media/Videos/") + filename;
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/octet-stream", filename);
        }

        public ActionResult DeleteFile(string filename)//allows the user to delete any file they choose from /Media/Videos/
        {
            string filePath = Server.MapPath("~/Media/Videos/") + filename;
            System.IO.File.Delete(filePath);
            return RedirectToAction("Video");
        }
    }
}