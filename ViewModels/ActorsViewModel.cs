using System.Collections.Generic;
using Test.Data.Models;

namespace Test.ViewModels
{
    public class ActorsViewModel
    {
        public IEnumerable<Actor> allActors { get; set; }
        public string sortedBy { get; set; }
    }
}
