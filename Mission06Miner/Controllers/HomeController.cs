using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06Miner.Models;

namespace Mission06Miner.Controllers
{
    public class HomeController : Controller
    {

        private MovieContext _context;
        
        public HomeController(MovieContext temp) //contstructor
        {
            _context = temp;
        }

        //create actions to pull up the different views
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovie()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult EnterMovie(Movie response)
        {
  
            //add and save the reponse
            _context.Movies.Add(response);
            _context.SaveChanges();

            //show confirmatin page
            return View("Confirmation");

        }

        public IActionResult MovieList()
        {
            var movielist = _context.Movies
            //.Include(x => x.Categories)
            .OrderBy(x => x.MovieId).ToList();



            return View(movielist);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("EnterMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie response)
        {
            _context.Movies.Update(response);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
