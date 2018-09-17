using System.IO;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using SimpleWebApp.Models;

namespace SimpleWebApp.Controllers
{
    public class HomeController : Controller
    {
        private ImageContext context = new ImageContext();

        public ActionResult Index()
        {
            return this.View(this.context.DbImages);
        }

        public ActionResult LoremIpsum() => this.View();

        public ActionResult About() => this.View();

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase image)
        {
            if (image != null)
            {
                byte[] imageData = null;
                var dataImage = new DbImage();

                using (var reader = new BinaryReader(image.InputStream))
                {
                    imageData = reader.ReadBytes(image.ContentLength);
                    WebImage webImage = new WebImage(image.InputStream);
                    webImage.Resize(400, 400, true, true);
                    dataImage.Thumbnail = webImage.GetBytes();
                }
                
                dataImage.Full = imageData;
                dataImage.Name = Path.GetFileNameWithoutExtension(image.FileName);

                this.context.DbImages.Add(dataImage);
                this.context.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View("Index");
        }
    }
}
