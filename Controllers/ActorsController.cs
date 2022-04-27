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
    public class ActorsController : Controller
    {
        private readonly IMovie _allMovies;
        private readonly IActor _allActors;
        private readonly AppDBContent appDBContent;
        public ActorsController(IMovie iMovie, IActor iActor, AppDBContent appDBContent)
        {
            _allMovies = iMovie;
            _allActors = iActor;
            this.appDBContent = appDBContent;
        }

        [Route("Actors/Index")]
        [Route("Actors/Index/{sortBy}")]
        public ViewResult Index(string sortBy)
        {
            IEnumerable<Actor> actors = null;
            string sortedBy = "";
            if (string.IsNullOrWhiteSpace(sortBy) || string.Equals(("mostPopular"), sortBy, StringComparison.OrdinalIgnoreCase))
            {
                actors = _allActors.allActors.OrderByDescending(m => m.actorRating);
                sortedBy = "Популярные";
            }
            else if (string.Equals(("byHeight"), sortBy, StringComparison.OrdinalIgnoreCase))
            {
                actors = _allActors.allActors.OrderByDescending(m => m.height);
                sortedBy = "Самые высокие";
            }

            var actorObj = new ActorsViewModel
            {
                allActors = actors,
                sortedBy = sortedBy
            };

            ViewBag.Title = "Страница с актерами";
            return View(actorObj);
        }

        [Route("Movies/actorInfo/{id}")]
        public ViewResult actorInfo(int id)
        {
            Actor act = _allActors.getObjectActor(id);
            ViewBag.Title = act.actorName;
            var actObj = new ActorViewModel { actor = act, movies = new List<Movie>() };
            var actMovies = act.movies.Split(' ');
            foreach (var movie in actMovies)
            {
                actObj.movies.Add(_allMovies.getObjectMovie(movie));
            }
            return View(actObj);
        }

        public RedirectToActionResult addRating(int id)
        {
            this.appDBContent.Actors.FirstOrDefault(a => a.id == id).actorRating++;
            appDBContent.SaveChanges();
            return RedirectToAction("actorInfo", id);
        }
    }
}
