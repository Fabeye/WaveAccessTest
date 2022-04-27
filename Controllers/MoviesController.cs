using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Data;
using Test.Data.Interfaces;
using Test.Data.Models;
using Test.ViewModels;

namespace Test.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovie _allMovies;
        private readonly IActor _allActors;
        private readonly AppDBContent appDBContent;
        public MoviesController(IMovie iMovie, IActor iActor, AppDBContent appDBContent)
        {
            _allMovies = iMovie;
            _allActors = iActor;
            this.appDBContent = appDBContent;
        }

        [Route("Movies/Index")]
        [Route("Movies/Index/{sortBy}")]
        public ViewResult Index(string sortBy)
        {
            IEnumerable<Movie> movies = null;
            string sortedBy = "";
            if (string.IsNullOrWhiteSpace(sortBy) || string.Equals(("mostPopular"), sortBy, StringComparison.OrdinalIgnoreCase))
            {
                movies = _allMovies.allMovies.OrderByDescending(m => m.movieRating);
                sortedBy = "Популярные";
            }
            else if (string.Equals(("byAlphabet"), sortBy, StringComparison.OrdinalIgnoreCase))
            {
                movies = _allMovies.allMovies.OrderByDescending(m => m.movieName);
                sortedBy = "По алфавитному порядку";
            }
            else if(string.Equals(("byPremiereDate"), sortBy, StringComparison.OrdinalIgnoreCase))
            {
                movies = _allMovies.allMovies.OrderByDescending(m => m.premiereDate);
                sortedBy = "Новинки";
            }

            var movieObj = new MoviesListViewModel
            {
                allMovies = movies,
                sortedBy = sortedBy
            };

            ViewBag.Title = "Страницас с фильмами";
            return View(movieObj);
        }

        [Route("Movies/Info/{id}")]
        public ViewResult Info(int id)
        {
            Movie mov = _allMovies.getObjectMovie(id);
            ViewBag.Title = mov.movieName;
            var movObj = new MovieListViewModel { movie = mov, actors = new List<Actor>() };
            var movActors = mov.actors.Split(' ');
            foreach (var actor in movActors)
            {
                movObj.actors.Add(_allActors.getObjectActor(actor));
            }
            return View(movObj);
        }

        public RedirectToActionResult addRating(int id)
        {
            this.appDBContent.Movies.FirstOrDefault(m => m.id == id).movieRating++;
            appDBContent.SaveChanges();
            return RedirectToAction("Info", id);
        }
    }


}
