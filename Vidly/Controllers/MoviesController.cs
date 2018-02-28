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

        public ActionResult New(int? id)
        {
            var movie = _context.Movies.Find(id);

            
            var movieFormModel = new MovieFormModel() {Movie=movie, Genres = GetGenres() };

            return View(movieFormModel);
        }

        public ActionResult Save(Movie movie)
        {
            var movieGenre= GetGenres().Find(g => g.Id == movie.GenreId);

            if (movie.Id==0)
            {
                movie.DateAdded = DateTime.Now;
                movie.Genre = movieGenre;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieModel = _context.Movies.Single(m => m.Id == movie.Id);

                movieModel.Name = movie.Name;
                movieModel.Genre = movieGenre;
                movieModel.NumberInStock = movie.NumberInStock;
                movieModel.DateAdded = DateTime.Now;
                movieModel.ReleaseDate = movie.ReleaseDate;
                movieModel.GenreId =movie.GenreId;

            }
            

            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        private List<Genre> GetGenres()
        {
            return _context.Genres.Distinct().ToList() ;
        }
    }
}