using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using Server.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Server.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IFileProvider _fileProvider;

        public HomeController(ILogger<HomeController> logger, IFileProvider fileProvider, MyContext context)
        {
            _logger = logger;
            _fileProvider = fileProvider;
            dbContext = context;
        }

        [HttpGet("login")]
        public IActionResult adminreg()
        {
            
            return View("Register");
        }
        [HttpPost("Home/Register")]
        public IActionResult RegisterForm(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.User.Any(l => l.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email is already in use!");
                    return View("Register");
                }
                if(dbContext.User.Any(l => l.Username == newUser.Username))
                {
                    ModelState.AddModelError("Username", "Username is already in use!");
                    return View("Register");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                dbContext.Add(newUser);
                dbContext.SaveChanges();
            }
            return View("Register");
        }
       [HttpPost("Home/LoginSubmit")]
        public IActionResult LoginForm(LoginUser userSubmission)
        {
            if(ModelState.IsValid)
            {
                User userInDb = dbContext.User.FirstOrDefault(u => u.Username == userSubmission.Username);
                if (userInDb == null)
                {
                    ModelState.AddModelError("Username", "Invalid Username/Password");
                    return View("Register");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if(result == 0)
                {
                    ModelState.AddModelError("Password", "Invalid Email/Password");
                    return View("Register");
                }
                HttpContext.Session.SetString("Username", $"{userInDb.Username}");
                return RedirectToAction("Index");
            }
            return View("Register");
        }
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if(file == null || file.Length ==0)
            {
                return Content("Please select file");
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/uploaded_images", file.FileName);

            using(var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("Gallery");
        }
        public async Task<IActionResult> UploadFiles(List<IFormFile> files) 
        {
            if(files == null || files.Count == 0)
                return Content("Please select at least one file");
            
            foreach(var file in files ){

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/uploaded_images", file.FileName);

                using(var stream = new FileStream(path, FileMode.Create)){
                    await file.CopyToAsync(stream);
                }
            }

            return RedirectToAction("Gallery");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            return View("About");
        }

        [HttpGet("gallery")]
        public IActionResult Gallery()
        {
            var model = new FileViewModel();
            foreach(var item in this._fileProvider.GetDirectoryContents(""))
            {
                model.Files.Add(new FileDetails{
                    Name= item.Name, Path = item.PhysicalPath
                });
            }
            if(HttpContext.Session.GetString("Username") == "admin")
            {
                ViewBag.adminboolean = true;
            }

            return View("Gallery", model);
        }

        [HttpPost("delete/{file}")]
        public IActionResult DeletePic(string file)
        {
            Console.WriteLine($"I HAVE BEEN EXECUTED, FILE NAME IS {file}");
            if(System.IO.File.Exists($@"C:\Users\root\Desktop\portfolio\GymnasticsDanceTampaBay\Server\wwwroot\images\uploaded_images\{file}"))
            {
                try {
                    System.IO.File.Delete($@"C:\Users\root\Desktop\portfolio\GymnasticsDanceTampaBay\Server\wwwroot\images\uploaded_images\{file}");
                }
                catch (System.IO.IOException e) {
                    Console.WriteLine("there was an error trying to delete ${file}");
                    Console.WriteLine(e.Message);
                }
            }
            return RedirectToAction("Gallery");
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
