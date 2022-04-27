using System.Collections.Generic;
using Test.Data.Models;

namespace Test.Data.Interfaces
{
    public interface IMovie
    {
        IEnumerable<Movie> allMovies { get;}
        Movie getObjectMovie(int movieId);
        Movie getObjectMovie(string movieName);
    }
}
