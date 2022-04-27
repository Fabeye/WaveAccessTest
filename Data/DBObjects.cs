using System;
using System.Collections.Generic;
using System.Linq;
using Test.Data.Models;

namespace Test.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Actors.Any())
                content.Actors.AddRange(AddActors.Select(a => a.Value));

            if (!content.Movies.Any())
                content.Movies.AddRange(AddMovies.Select(m => m.Value));

            content.SaveChanges();
        }

        private static Dictionary<string, Actor> actor;
            
        public static Dictionary<string, Actor> AddActors
        {
            get
            {
                if (actor == null)
                {
                    var list = new Actor[]
                    {
                        new Actor
                        {
                            actorName = "Актер1",
                            actorInfo = "информация про Актер1",
                            height = 162,
                            actorRating = 101,
                            img = "/img/1.jpg",
                            movies = "Фильм1 Фильм2 Фильм5 Фильм7"
                        },
                        new Actor
                        {
                            actorName = "Актер2",
                            actorInfo = "информация про Актер2",
                            height = 199,
                            actorRating = 102,
                            img = "/img/2.jpg",
                            movies = "Фильм2 Фильм3 Фильм4"
                        },
                        new Actor
                        {
                            actorName = "Актер3",
                            actorInfo = "информация про Актер3",
                            height = 198,
                            actorRating = 103,
                            img = "/img/3.jpg",
                            movies = "Фильм6 Фильм7"
                        },
                        new Actor
                        {
                            actorName = "Актер4",
                            actorInfo = "информация про Актер4",
                            height = 197,
                            actorRating = 104,
                            img = "/img/4.jpg",
                            movies = "Фильм2 Фильм4 Фильм5"
                        },
                        new Actor
                        {
                            actorName = "Актер5",
                            actorInfo = "информация про Актер5",
                            height = 180,
                            actorRating = 105,
                            img = "/img/5.jpg",
                            movies = "Фильм6"
                        },
                        new Actor
                        {
                            actorName = "Актер6",
                            actorInfo = "информация про Актер6",
                            height = 195,
                            actorRating = 106,
                            img = "/img/6.jpg",
                            movies = "Фильм1 Фильм5"
                        },
                        new Actor
                        {
                            actorName = "Актер7",
                            actorInfo = "информация про Актер7",
                            height = 176,
                            actorRating = 107,
                            img = "/img/7.jpg",
                            movies = "Фильм4"
                        },
                        new Actor
                        {
                            actorName = "Актер8",
                            actorInfo = "информация про Актер8",
                            height = 193,
                            actorRating = 108,
                            img = "/img/8.jpg",
                            movies = "Фильм1 Фильм2 Фильм3 Фильм4 Фильм5 Фильм6 Фильм7"
                        },
                        new Actor
                        {
                            actorName = "Актер9",
                            actorInfo = "информация про Актер9",
                            height = 212,
                            actorRating = 109,
                            img = "/img/9.jpg",
                            movies = "Фильм1 Фильм7"
                        }
                    };

                    actor = new Dictionary<string, Actor>();
                    foreach (Actor a in list)
                        actor.Add(a.actorName, a);
                }

                return actor;
            }
        }

        private static Dictionary<string, Movie> movie;

        public static Dictionary<string, Movie> AddMovies
        {
            get
            {
                if (movie == null)
                {
                    var list = new Movie[]
                    {
                        new Movie
                        {
                            movieName = "Фильм1",
                            movieInfo = "информация про Фильм1",
                            premiereDate = new DateTime(2011, 3, 6),
                            movieRating = 101,
                            img = "/img/1.jpg",
                            actors = "Актер1 Актер6 Актер8 Актер9"
                        },
                        new Movie
                        {
                            movieName = "Фильм2",
                            movieInfo = "информация про Фильм2",
                            premiereDate = new DateTime(2002, 3, 6),
                            movieRating = 102,
                            img = "/img/2.jpg",
                            actors = "Актер1 Актер2 Актер8"
                        },
                        new Movie
                        {
                            movieName = "Фильм3",
                            movieInfo = "информация про Фильм3",
                            premiereDate = new DateTime(2013, 3, 6),
                            movieRating = 103,
                            img = "/img/3.jpg",
                            actors = "Актер2 Актер4 Актер8"
                        },
                        new Movie
                        {
                            movieName = "Фильм4",
                            movieInfo = "информация про Фильм4",
                            premiereDate = new DateTime(2004, 3, 6),
                            movieRating = 104,
                            img = "/img/4.jpg",
                            actors = "Актер2 Актер7 Актер8"
                        },
                        new Movie
                        {
                            movieName = "Фильм5",
                            movieInfo = "информация про Фильм5",
                            premiereDate = new DateTime(2015, 3, 6),
                            movieRating = 105,
                            img = "/img/5.jpg",
                            actors = "Актер1 Актер4 Актер6 Актер8"
                        },
                        new Movie
                        {
                            movieName = "Фильм6",
                            movieInfo = "информация про Фильм6",
                            premiereDate = new DateTime(2006, 3, 6),
                            movieRating = 106,
                            img = "/img/6.jpg",
                            actors = "Актер3 Актер5 Актер6"
                        },
                        new Movie
                        {
                            movieName = "Фильм7",
                            movieInfo = "информация про Фильм7",
                            premiereDate = new DateTime(2017, 3, 6),
                            movieRating = 107,
                            img = "/img/7.jpg",
                            actors = "Актер1 Актер3 Актер8 Актер9"
                        },
                    };

                    movie = new Dictionary<string, Movie>();
                    foreach (Movie m in list)
                        movie.Add(m.movieName, m);
                }
                return movie;
            }
        }


    }
}
