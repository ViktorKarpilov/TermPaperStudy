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
        private readonly ApplicationDbContext _context;
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment environment;

        public HomeController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env,ApplicationDbContext context){
            environment = env;
            _context = context;
        }
        
        public IActionResult Delete(int id){
            _context.Users.Remove(_context.Users.Where(user => user.ID ==id).ToArray()[0]);
            _context.SaveChanges();
            return RedirectToActionPermanent("Main");
        }

        [HttpGet("")]
        public IActionResult Main(){
            byte[] ByteUserId = new byte[4];
            HttpContext.Session.TryGetValue("UserID",out ByteUserId);
            if(ByteUserId==null){
                return View("Main", _context.Users.ToArray()); 
            }
            Array.Reverse(ByteUserId);
            int UserId = BitConverter.ToInt32(ByteUserId,0);
            ViewData["User"] = _context.Users.Find(UserId).Username;

            return View("Main", _context.Users.ToArray()); 
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/registration")]
        public PartialViewResult Registration(){
            return PartialView("_RegistrationPartial");
        }

        [HttpPost("/LogPost")]
        public IActionResult LoginPost(string Username, string Password)
        {
            if (_context.Users.Where(element => element.Username == Username).Count() == 0)
            {
                
                return StatusCode(403);
            }

            User user = _context.Users.Where(element => element.Username == Username).ToArray()[0];
            if (user.ComparePassword(Password))
            {
                byte[] state = new byte[1];
                state[0] = 1;
                byte[] id = BitConverter.GetBytes(user.ID);
                Array.Reverse(id);
                HttpContext.Session.Set("IsLoged", state);
                HttpContext.Session.Set("UserID", id);

                //TODO
                //return RedirectToActionPermanent("Main");;
                ViewData["User"] = user.Username;
                return Ok();
            }
            //TODO
            //return RedirectToActionPermanent("Main");;
            return StatusCode(403);
        }

        public IActionResult LogOutPost()
        {
            HttpContext.Session.Set("IsLoged", new byte[1]{0});
            return RedirectToActionPermanent("Main");;
        }

        [HttpPost("/reg")]
        public IActionResult RegPost(string Username,string Password,string Email){
            if(_context.Users.Where(user => user.Username==Username).ToArray().Length!=0){
                //TODO something better
                return RedirectToActionPermanent("Main");
            }
            _context.Add(new User(Username,Email,Password));
            _context.SaveChanges();


            return RedirectToActionPermanent("Main");
        }

        [HttpGet("/react")]
        public PartialViewResult React(){
            return PartialView("_ReactPage");
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
            ViewData["User"] = "Vasiliy";
            return PartialView("_MainPartial");            
        }

        [HttpGet("Login")]
        public PartialViewResult LogInPage(){
            return PartialView("_LogInPartial");
        }

        public IActionResult CommentPost(string Comment){

            HttpContext.Session.TryGetValue("UserID",out byte[] a);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(a);
            int id = BitConverter.ToInt32(a,0);
            
            CommentModel comment = new CommentModel(_context.Users.Find(id).Username,Comment);
            _context.Add(comment);
            _context.SaveChanges();
            

            return RedirectToActionPermanent("Main");
        }
        
        [HttpGet("/comments")]
        public IActionResult CommentsPage(){
            byte[] IsLoged = new byte[1];
            HttpContext.Session.TryGetValue("IsLoged",out IsLoged);
            if(IsLoged==null || IsLoged[0] != 1 ){
                return RedirectToActionPermanent("LogInPage");
            }
            
            return PartialView("_CommentsWidjet",_context.Comments.ToArray());
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
