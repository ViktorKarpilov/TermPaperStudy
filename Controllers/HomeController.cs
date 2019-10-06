using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermPaper.Models;

namespace TermPaper.Controllers
{
    public class HomeController : Controller
    {
        
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment environment;

        public HomeController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env){
            environment = env;
        }

        [HttpGet("")]
        public IActionResult Main(){
            
            return View(); 
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("/registration")]
        public PartialViewResult Registration(){
            return PartialView("_RegistrationPartial");
        }

        [HttpGet("/photos")]
        public PartialViewResult Photos(){
            Dictionary<string,string> testDict = new Dictionary<string, string>();

            //testing case
            testDict.Add("test","/images/paint.jpg");
            testDict.Add("test2","/images/books.jpg");
            testDict.Add("test3","/images/DarkNature.jpg");
            testDict.Add("test4","/images/nature.jpg");
            testDict.Add("test5","/images/photo.jpg");
            testDict.Add("test6","/images/waterfall.jpg");
            testDict.Add("test7","/images/whiteTree.jpg");
            

            return PartialView("_PhotosPartial",new PhotoPageModel(testDict));
        }

        [HttpGet("/main")]
        public PartialViewResult PartialMainPage(){
            return PartialView("_MainPartial");            
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
