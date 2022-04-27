using System.Collections.Generic;
using Test.Data.Models;

namespace Test.ViewModels
{
    public class MovieListViewModel
    {
        public Movie movie { get; set; }
        public List<Actor> actors { get; set; }
    }
}
