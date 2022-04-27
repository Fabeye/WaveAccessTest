using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Test.Data.Interfaces;
using Test.Data.Models;

namespace Test.Data.Repository
{
    public class MoviesRepository : IMovie
    {
        private readonly AppDBContent appDBContent;

        public MoviesRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent; 
        }
        public IEnumerable<Movie> allMovies => appDBContent.Movies;

        public Movie getObjectMovie(int movieId) => appDBContent.Movies.FirstOrDefault(m => m.id == movieId);

        public Movie getObjectMovie(string movieName) => appDBContent.Movies.FirstOrDefault(m => m.movieName == movieName);
    }
}
