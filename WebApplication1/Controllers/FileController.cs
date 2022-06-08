using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Files()
        {

            string[] Paths = Directory.GetFiles(Server.MapPath("~/Media/Documents/"));
            List<FileModel> files = new List<FileModel>();
            foreach (string FPath in Paths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(FPath) });
            }
            return View(files);
        }

        public FileResult Download(string file)
        {
            string path = Server.MapPath("~/Media/Documents/") + file;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", file);
        }

        public ActionResult Delete(string file)
        {

            string path = Server.MapPath("~/Media/Documents/") + file;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            System.IO.File.Delete(path);
            return RedirectToAction("Index");
        }
    }
}