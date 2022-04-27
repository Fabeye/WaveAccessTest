using System.Collections.Generic;
using Test.Data.Models;

namespace Test.ViewModels
{
    public class MoviesListViewModel
    {
        public IEnumerable<Movie> allMovies { get; set; }
        public string sortedBy { get; set; }
    }
}
