using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Models
{
    public class Actor
    {
        public int id { get; set; }
        public int height { get; set; }
        public string actorName { get; set; }
        public string actorInfo { get; set; }
        public string img { get; set; }
        public int actorRating { get; set; }

        public string movies { get; set; }

    }
}
