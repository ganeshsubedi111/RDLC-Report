using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using AspNetCore.Reporting;
using System.Collections.Generic;
using System.IO;

namespace RDLCREPORTFILES.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReportController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Print()
        {
            string mimeType = "application/pdf";
            int extension = 1;
            var path = Path.Combine(this._webHostEnvironment.WebRootPath, "Reports", "Report1.rdlc");

            Dictionary<string,string> parameters = new Dictionary<string, string>();
            parameters.Add("rp", "Welcome to insoft");
            LocalReport localReport = new LocalReport(path);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimeType);

            return File(result.MainStream, mimeType);
        }
    }
}