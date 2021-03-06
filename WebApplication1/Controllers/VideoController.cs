using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Videos()
        {

            string[] Paths = Directory.GetFiles(Server.MapPath("~/Media/Videos/"));

            List<FileModel> files = new List<FileModel>();

            foreach (string fPath in Paths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(fPath) });
            }
            return View(files);
        }

        public FileResult Download(string file)
        {
            string path = Server.MapPath("~/Media/Videos/") + file;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", file);
        }

        public ActionResult Delete(string file)
        {

            string path = Server.MapPath("~/Media/Videos/") + file;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Videos");
        }
    }
}