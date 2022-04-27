using System.Collections.Generic;
using Test.Data.Models;

namespace Test.Data.Interfaces
{
    public interface IActor
    {
        IEnumerable<Actor> allActors { get;}
        Actor getObjectActor(int actorId);
        Actor getObjectActor(string actorName);
    }
}
