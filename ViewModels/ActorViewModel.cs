using System.Collections.Generic;
using Test.Data.Models;

namespace Test.ViewModels
{
    public class ActorViewModel
    {
        public Actor actor { get; set; }
        public List<Movie> movies { get; set; }
    }
}
