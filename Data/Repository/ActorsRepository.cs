using System.Collections.Generic;
using System.Linq;
using Test.Data.Interfaces;
using Test.Data.Models;

namespace Test.Data.Repository
{
    public class ActorsRepository : IActor
    {
        private readonly AppDBContent appDBContent;

        public ActorsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Actor> allActors => appDBContent.Actors;

        public Actor getObjectActor(int actorId) => appDBContent.Actors.FirstOrDefault(a => a.id == actorId);

        public Actor getObjectActor(string actorName) => appDBContent.Actors.FirstOrDefault(a => a.actorName == actorName);
    }
}
