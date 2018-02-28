using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1" },
                new Customer {Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
          
      
            return View(movies);
        }

        public ActionResult Edit(int id)
        {
            
            return Content("id=" + id);
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m=>m.Genre).FirstOrDefault(m=>m.Id==id);

            if (movie==null)
            {
                return HttpNotFound();
            }
            return View(movie);

        }

        public ActionResult New()
        {
            var movieFormModel = new MovieFormModel() { Genres = GetGenres() };

            return View(movieFormModel);
        }


        private List<Genre> GetGenres()
        {
            return _context.Genres.ToList() ;
        }
    }
}