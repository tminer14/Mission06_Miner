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
        
        public HomeController(MovieContext temp) //constructor
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
            //create viewbag to store categories 
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(new Movie()); //fix the issue with the ID number by creating new instance
        }

        [HttpPost]
        public IActionResult EnterMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                //add and save the reponse
                _context.Movies.Add(response);
                _context.SaveChanges();

                //show confirmatin page
                return View("Confirmation");
            }
            else
            {
                ViewBag.Categories = _context.Categories
               .OrderBy(x => x.CategoryName)
               .ToList();

                return View(response);
        
             }

        }

        public IActionResult MovieList()
        {
            //display all of the movies
            var movielist = _context.Movies
            .Include(x => x.Category)//join categories table
            .OrderBy(x => x.MovieId).ToList();


             return View(movielist);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //store record as variable to be passed into return statement
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
            //update and save response
            _context.Movies.Update(response);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //collet info to know where record is
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            //delete, save, redirect
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
