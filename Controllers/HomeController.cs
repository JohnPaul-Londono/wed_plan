using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using wed_plan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace wed_plan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.eMail == newUser.eMail))
                {
                    ModelState.AddModelError("email", "Email already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.password = Hasher.HashPassword(newUser, newUser.password);
                _context.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("LoggedIn", newUser.UserId);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoggedUser logUser)
        {
            if (ModelState.IsValid)
            {
                // find one user using first or deafult and the email provided
                User userinDB = _context.Users.FirstOrDefault(u => u.eMail == logUser.leMail);
                // when we search using first or default if nothing comes back we get null, 
                if (userinDB == null)
                {
                    ModelState.AddModelError("leMail", "Invalid Login Attempt!");
                    return View("Index");
                }
                PasswordHasher<LoggedUser> Hasher = new PasswordHasher<LoggedUser>();
                PasswordVerificationResult result = Hasher.VerifyHashedPassword(logUser, userinDB.password, logUser.lpassword);
                if (result == 0)
                {
                    ModelState.AddModelError("leMail", "Invalid login attempt");
                    return View("Index");
                }
                HttpContext.Session.SetInt32("LoggedIn", userinDB.UserId);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Index");
            }
        }



        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            int? loggedIn = HttpContext.Session.GetInt32("LoggedIn");
            if (loggedIn != null)
            {
                ViewBag.LoggedIn = _context.Users.FirstOrDefault(d => d.UserId == (int)HttpContext.Session.GetInt32("LoggedIn"));
                ViewBag.AllWeddings = _context.Weddings.OrderBy(a => a.CreatedAt).Include(g => g.guestlist).ToList();
                return View("Dashboard");
            }
            else
            {
                return View("Index");
            }
        }

        // __________________________________
        // - - - - - -New Wedding - - - - - - - 
        // _________________________________
        [HttpGet("addWedding")]
        public IActionResult AddWedding()
        {
            int? LoggedIn = HttpContext.Session.GetInt32("LoggedIn");
            if (LoggedIn == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.UserId = Convert.ToInt32(LoggedIn);
            return View();
        }

        [HttpPost("planWedding")]
        public IActionResult PlanWedding(Wedding plannedWedding)
        {
            if (ModelState.IsValid)
            {
                if (plannedWedding.dateofWedding > DateTime.Now)
                {
                    _context.Add(plannedWedding);
                    _context.SaveChanges();
                    return Redirect("Dashboard");
                }
                else
                {
                    int? LoggedIn = HttpContext.Session.GetInt32("LoggedIn");
                    ViewBag.UserId = Convert.ToInt32(LoggedIn);
                    ModelState.AddModelError("dateofWedding", "Date should be in the future.");
                    return View("AddWedding");
                }
            }
            else
            {
                return View("AddWedding");
            }
        }
        // __________________________________
        // - - - - - -View Wedding - - - - - - - 
        // _________________________________

        [HttpGet("wedding/{weddingId}")]
        public IActionResult OneWedding(int weddingId)
        {
            int? LoggedIn = HttpContext.Session.GetInt32("LoggedIn");
            if (LoggedIn == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Wedding one = _context.Weddings.Include(c => c.guestlist).ThenInclude(ti => ti.User).FirstOrDefault(fd => fd.WeddingId == weddingId);
                ViewBag.AllUsers = _context.Users.OrderBy(u => u.firstName).ToList();
                return View(one);
            }
        }
        // __________________________________
        // - - - - - -EDIT Wedding Page - - - - - - - 
        // _________________________________
        [HttpGet("edit/{weddingid}")]
        public IActionResult Edit(int weddingid)
        {
            if (HttpContext.Session.GetInt32("LoggedIn") == null)
            {
                return RedirectToAction("Index");
            }
            Wedding weddingEdit = _context.Weddings.FirstOrDefault(d => d.WeddingId == weddingid);
            return View(weddingEdit);
        }
        // __________________________________
        // - - - - - -UPDATE Wedding Page - - - - - - - 
        // _________________________________
        [HttpPost("update/{weddingid}")]
        public IActionResult Update(int weddingid, Wedding WeddingUpdate)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetInt32("LoggedIn") == null)
                {
                    return RedirectToAction("Index");
                }
                Wedding weddingtoUpdate = _context.Weddings.FirstOrDefault(d => d.WeddingId == weddingid);
                if (HttpContext.Session.GetInt32("LoggedIn") != weddingtoUpdate.UserId)
                {
                    return RedirectToAction("Logout");
                }
                weddingtoUpdate.person1 = WeddingUpdate.person1;
                weddingtoUpdate.person2 = WeddingUpdate.person2;
                weddingtoUpdate.dateofWedding = WeddingUpdate.dateofWedding;
                weddingtoUpdate.Address = weddingtoUpdate.Address;
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            } else {
                return View("Edit");
            }

        }



        // __________________________________
        // - - - - - -Delete Wedding - - - - - - - 
        // _________________________________

        [HttpGet("delete/{weddingid}")]
        public IActionResult Delete(int weddingid)
        {
            Wedding toDelete = _context.Weddings.SingleOrDefault(f => f.WeddingId == weddingid);
            if (HttpContext.Session.GetInt32("LoggedIn") != toDelete.UserId)
            {
                return RedirectToAction("Logout");
            }
            else
            {
                _context.Weddings.Remove(toDelete);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }

        // __________________________________
        // - - - - - -RSVP - - - - - - - 
        // _________________________________
        [HttpGet("RSVP/{weddingid}/{userid}")]
        public IActionResult RSVPwedding(int weddingid, int userid)
        {
            if (HttpContext.Session.GetInt32("LoggedIn") == null)
            {
                return RedirectToAction("Index");
            }
            if ((int)HttpContext.Session.GetInt32("LoggedIn") != userid)
            {
                return RedirectToAction("Logout");
            }
            RSVP newRSVP = new RSVP();
            newRSVP.WeddingId = weddingid;
            newRSVP.UserId = userid;
            _context.Add(newRSVP);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        // __________________________________
        // - - - - - -unRSVP - - - - - - - 
        // _________________________________

        [HttpGet("unRSVP/{weddingid}/{userid}")]
        public IActionResult unRSVPwedding(int weddingid, int userid)
        {
            if (HttpContext.Session.GetInt32("LoggedIn") == null)
            {
                return RedirectToAction("Index");
            }
            if ((int)HttpContext.Session.GetInt32("LoggedIn") != userid)
            {
                return RedirectToAction("Logout");
            }
            RSVP unRSVPwedd = _context.RSVPs.FirstOrDefault(f => f.WeddingId == weddingid && f.UserId == userid);
            _context.RSVPs.Remove(unRSVPwedd);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");

        }
        // __________________________________
        // - - - - - -LOGGING OUT - - - - - - - 
        // _________________________________

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        // __________________________________
        // - - - - - -PRIVACY - - - - - - - 
        // _________________________________

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
