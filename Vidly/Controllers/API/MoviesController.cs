using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;


        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET api/<controller>
        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies.ToList();

            return Ok(movies);
        }

        // GET api/<controller>/5
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie==null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            movie.DateAdded = DateTime.Now;
            movie.Genre = _context.Genres.Find(movie.GenreId);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id,Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb==null)
            {
                return NotFound();
            }
            Mapper.CreateMap<Movie,Movie>().ForMember(m=>m.DateAdded,opt=>opt.Ignore());
            Mapper.CreateMap<Movie, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
            movieInDb = Mapper.Map(movie,movieInDb);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}