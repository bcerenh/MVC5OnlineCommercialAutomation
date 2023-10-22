using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;

namespace MvcWebTicariOtomasyon.Controllers
{
    public class QRController : Controller
    {
        // GET: QR
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string kod)
        {
            using (MemoryStream stream = new MemoryStream())  //memorysteam resim ekleme ,qr ekleme de kullanılır
            {
                QRCodeGenerator codeGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = codeGenerator.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);
                using(Bitmap resim=karekod.GetGraphic(10))
                {
                    resim.Save(stream, ImageFormat.Png);
                    ViewBag.QRCode = "data:image/png;base64," + Convert.ToBase64String(stream.ToArray());
                }
            }
            return View();
        }
    }
}