using System.Diagnostics;
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

    }
}
