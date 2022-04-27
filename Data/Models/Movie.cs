using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string movieName { get; set; }
        public string movieInfo { get; set; }
        public string img { get; set; }
        public DateTime premiereDate { get; set; }
        public int movieRating { get; set; }

        public string actors { get; set; }
    }
}
