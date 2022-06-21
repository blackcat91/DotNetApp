using MVCIntermediate.Models;

namespace MVCIntermediate.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //Cinema
                if (!context.Cinemas.Any())
                {

                    context.Cinemas.AddRange(new List<Cinema> {

                    new Cinema
                    {
                        Name = "Theatre 1",
                        Logo = "https://cdn.celluloidjunkie.com/wp-content/uploads/2021/12/22064111/AMC-1250x781.png",
                        Description = "AMC Theatres"
                    },
                    new Cinema
                    {
                        Name = "Theatre 2",
                        Logo = "https://www.pointruston.com/wp-content/uploads/2017/04/Point-Ruston_Century-Theaters_logo_2.png",
                        Description = "Century Theatres"
                    },
                    new Cinema
                    {
                        Name = "Theatre 3",
                        Logo = "https://is4-ssl.mzstatic.com/image/thumb/Purple114/v4/fd/62/a1/fd62a1c3-6178-1422-aa49-f80917cbaabe/source/512x512bb.jpg",
                        Description = "B&B Theatres"
                    },
                    new Cinema
                    {
                        Name = "Theatre 4",
                        Logo = "https://www.layar.id/wp-content/uploads/2017/09/Logo-CinemaXXI.jpg",
                        Description = "Cinema 21"
                    }

                    });
                    context.SaveChanges();


                }

                //Producer
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer> {

                    new Producer
                    {
                        
                        FullName = "Michael Mann",
                        ProfilePicURL = "http://de.web.img3.acsta.net/pictures/14/06/05/12/11/300915.jpg",
                        Bio = "The Insider"
                    },
                    new Producer
                    {
                        
                        FullName = "James Cameron",
                        ProfilePicURL = "https://www.indiewire.com/wp-content/uploads/2018/04/sosf_mm_0827_0244-rt.jpg",
                        Bio = "Avatar"
                    },
                    new Producer
                    {
                        
                        FullName = "Steven Speilberg",
                        ProfilePicURL = "https://www.indiewire.com/wp-content/uploads/2018/03/shutterstock_9354169fc.jpg",
                        Bio = "E.T."
                    },
                    new Producer
                    {
                        
                        FullName = "Spike Lee",
                        ProfilePicURL = "https://www.indiewire.com/wp-content/uploads/2020/03/shutterstock_editorial_10300083s.jpg",
                        Bio = "Do The Right Thing"
                    },

                    });
                    context.SaveChanges();
                }
                //Actor
                if (!context.Actors.Any())
                {

                    context.Actors.AddRange(new List<Actor> {

                        new Actor   
                        {
                            FullName = "Samuel L Jackson",
                        ProfilePicURL = "http://africa.cgtn.com/wp-content/photo-gallery/2019/08/GettyImages-1152251903.jpg",
                        Bio = "Sam Jackson. Man is in everthing."
                        },
                        new Actor
                        {
                            FullName = "Cameron Diaz",
                        ProfilePicURL = "https://gozend.com/wp-content/uploads/2019/07/cameron-diaz.jpg",
                        Bio = "The lovely Cam Diam"
                        },
                        new Actor
                        {
                            FullName = "Al Pacino",
                        ProfilePicURL = "https://resize4.indiatvnews.com/en/resize/gallery/835_-/2019/12/5-2-1576508794.jpg",
                        Bio = "Living Legend"
                        },
                        new Actor
                        {
                            FullName = "Zoe Saldana",
                        ProfilePicURL = "https://www.hawtcelebs.com/wp-content/uploads/2019/04/zoe-saldana-at-missing-link-premiere-in-new-york-04-07-2019-0.jpg",
                        Bio = "BAD AF!!!!"
                        },

                    });
                    context.SaveChanges();
                }
                //Movie
                if (!context.Movies.Any())
                {

                    context.AddRange(new List<Movie> {

                        new Movie
                        {
                            Name = "The Insider",
                            Description ="A research chemist comes under personal and professional attack when he decides to appear in a 60 Minutes exposé on Big Tobacco.",
                            Price = 29.99,
                            ImageURL = "https://img.moviesrankings.com/t/p/w1280/3q0VmX7Hcjs5xX3YMs0C5IRskBL.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            Category = Enums.Category.Drama,
                            CinemaId = 2,
                            ProducerId = 5
                        },
                        new Movie
                        {
                            Name = "Avatar",
                            Description ="A paraplegic Marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home.",
                            Price = 34.99,
                            ImageURL = "https://image.tmdb.org/t/p/original/8Y7WrRK1iQHEX7UIftBeBMjPjWD.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            Category = Enums.Category.Action,
                            CinemaId = 1,
                            ProducerId = 6
                        },
                        new Movie
                        {
                            Name = "E.T.",
                            Description ="A troubled child summons the courage to help a friendly alien escape from Earth and return to his home planet.",
                            Price = 24.99,
                            ImageURL = "https://3.bp.blogspot.com/-81AgeopQ7ew/V6QFbby6HYI/AAAAAAAAjvM/3DzZer2uwecHIIquRgbbX7hO086ligs8ACLcB/s1600/ET.png",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            Category = Enums.Category.SciFi,
                            CinemaId = 3,
                            ProducerId = 7
                        },
                        new Movie
                        {
                            Name = "Do The Right Thing",
                            Description ="On the hottest day of the year on a street in the Bedford-Stuyvesant section of Brooklyn, everyone's hate and bigotry smolders and builds until it explodes into violence.",
                            Price = 29.99,
                            ImageURL = "https://i1.wp.com/icantunseethatmovie.com/wp-content/uploads/2019/06/DoTheRightThing_Poster.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            Category = Enums.Category.Drama,
                            CinemaId = 4,
                            ProducerId = 8
                        },

                    });

                    context.SaveChanges();

                }
                //Actor_Movie
                if (!context.Actors_Movies.Any())
                {

                    context.Actors_Movies.AddRange(new List<Actor_Movie> {

                        new Actor_Movie
                        {
                            ActorId= 1,
                            MovieId = 11
                        },
                        new Actor_Movie
                        {
                            ActorId= 2,
                            MovieId = 13
                        },
                        new Actor_Movie
                        {
                            ActorId= 3,
                            MovieId = 11
                        },
                        new Actor_Movie
                        {
                            ActorId= 4,
                            MovieId = 12
                        },

                        new Actor_Movie
                        {
                            ActorId= 2,
                            MovieId = 14
                        },
                        new Actor_Movie
                        {
                            ActorId= 1,
                            MovieId = 14
                        },

                    });

                    context.SaveChanges();
                }

            }
        }
    }
}
