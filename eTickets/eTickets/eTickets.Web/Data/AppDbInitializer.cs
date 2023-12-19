using eTickets.Web.Models;
using eTickets.Web.Models.Entities;
using eTickets.Web.Models.Enums;
using eTickets.Web.Models.Static;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Web.Data
{
    public class AppDbInitializer
    {

        // Entities Seeding
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            context.Database.EnsureCreated();

            // Cinema
            if (!context.Cinemas.Any())
            {
                context.Cinemas.AddRange(new List<Cinema>()
                {
                    new Cinema
                    {
                        Name="Cinema 1",
                        Logo="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQFbbJpUODh9aQfSWqOJlX9rZEyI2qOJk4BhQ&usqp=CAU",
                        Description="This is the description of the first cinema"
                    },
                    new Cinema
                    {
                        Name="Cinema 2",
                        Logo="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQrKi2mk0ZWiGp3DDEdhLQnTQtU8PrJVVI25A&usqp=CAU",
                        Description="This is the description of the second cinema"
                    },
                    new Cinema
                    {
                        Name="Cinema 3",
                        Logo="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2xgrE6DUBNnp3-rVS9WT-Y68-lWWbs7Fixw&usqp=CAU",
                        Description="This is the description of the third cinema"
                    },
                    new Cinema
                    {
                        Name="Cinema 4",
                        Logo="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQkk_0nGEmOWSbRFSdhHgYMMe5cz1Abx-XzzA&usqp=CAU",
                        Description="This is the description of the fourth cinema"
                    },
                    new Cinema
                    {
                        Name="Cinema 5",
                        Logo="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQaWHtsLOuivxOff_VXLOm2nGVaxbDSnpOu3g&usqp=CAU",
                        Description="This is the description of the fifth cinema"
                    }
                });
                context.SaveChanges();
            }

            // Actor

            if (!context.Actors.Any())
            {
                context.Actors.AddRange(new List<Actor>()
                {

                    new Actor
                    {
                        FullName="Actor 1",
                        Bio="This is Bio of the first actor",
                        ProfilePictureUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS6FP4k_lKTGGlk9FxPmVd-iIceb6-JiIVeAw&usqp=CAU"
                    },
                    new Actor
                    {
                        FullName="Actor 2",
                        Bio="This is Bio of the second actor",
                        ProfilePictureUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRxuN1ZjfD8Ss6kHWhHlyJgpPXbWesXTzSo0Q&usqp=CAU"
                    },
                    new Actor
                    {
                        FullName="Actor 3",
                        Bio="This is Bio of the thirth actor",
                        ProfilePictureUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSuIOB3yEiRbCxbIKgVBdRiPWkmAFa8hNzlRA&usqp=CAU"
                    },
                    new Actor
                    {
                        FullName="Actor 4",
                        Bio="This is Bio of the fourth actor",
                        ProfilePictureUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTY1-T1vWKRUHmpXu-XhtRWzE1kZeHeZVrDag&usqp=CAU"
                    },
                    new Actor
                    {
                        FullName="Actor 5",
                        Bio="This is Bio of the fifth actor",
                        ProfilePictureUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQFNjG0xo1_SR2BlevxpWk32UuzKdPR2bsn-g&usqp=CAU"
                    }

                });

                context.SaveChanges();
            }

            // Producer
            if (!context.Producers.Any())
            {
                context.Producers.AddRange(new List<Producer>()
                {
                    new Producer
                    {
                        FullName="Producer 1",
                        Bio="This is the bio of the first producer",
                        ProfilePictureUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSKnzElpDuwZl3FUcWMBi2nNb37GE8IxrTzOQ&usqp=CAU"
                    },
                    new Producer
                    {
                        FullName="Producer 2",
                        Bio="This is the bio of the second producer",
                        ProfilePictureUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTsVS-1QUi371ezxeiB5ITM5D6FaWhzM0D7fA&usqp=CAU"
                    },
                    new Producer
                    {
                        FullName="Producer 3",
                        Bio="This is the bio of the thirt producer",
                        ProfilePictureUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQPy1yEhyAPjQgf4ztFvktvOnz6Le1DDS4w8g&usqp=CAU"
                    },
                    new Producer
                    {
                        FullName="Producer 4",
                        Bio="This is the bio of the fourth producer",
                        ProfilePictureUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTK2NHTF65GRzLFa21VbgilfPUCSMehHq_Mlw&usqp=CAU"
                    },
                    new Producer
                    {
                        FullName="Producer 5",
                        Bio="This is the bio of the fifth producer",
                        ProfilePictureUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcThVF9bLPok9tvv7Kc5bCZd7N_yXENNz78NaA&usqp=CAU"
                    }
                });
                context.SaveChanges();
            }

            // Movie
            if (!context.Movies.Any())
            {
                context.Movies.AddRange(new List<Movie>()
                {

                    new Movie
                    {
                        Name="Ghost",
                        Description="This is the Ghost description",
                        ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTCu3oTQPridbHjuXUtDbUBMsbX5Z5b2Tj-5g&usqp=CAU",
                        StartDate=DateTime.Now,
                        EndDate=DateTime.Now.AddDays(7),
                        CinemaId=4,
                        ProducerId=4,
                        MovieCategory=MovieCategory.Horror
                    },
                    new Movie
                    {
                        Name="Race",
                        Description="This is the Race description",
                        ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSEy8-JTtaQ5MAh52Pej5CJN-HLSAelJeB3_Q&usqp=CAU",
                        StartDate=DateTime.Now.AddDays(-10),
                        EndDate=DateTime.Now.AddDays(-5),
                        CinemaId=1,
                        ProducerId=2,
                        MovieCategory=MovieCategory.Documentary
                    },
                    new Movie
                    {
                        Name="Scoob",
                        Description="This is the scoob movie description",
                        ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSEnF-ufsrSae4Y3vFwo_OZnFYvm_cYfkminA&usqp=CAU",
                        StartDate=DateTime.Now.AddDays(-10),
                        EndDate=DateTime.Now.AddDays(-2),
                        CinemaId=1,
                        ProducerId=3,
                        MovieCategory=MovieCategory.Cartoon
                    },

                    new Movie
                    {
                        Name="Cold Soles",
                        Description="This is the Cold Soles movie description",
                        ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQQu2osrbt788R7TXCX3n51lmCYlNStGsl6rw&usqp=CAU",
                        StartDate=DateTime.Now.AddDays(3),
                        EndDate=DateTime.Now.AddDays(20),
                        CinemaId=1,
                        ProducerId=5,
                        MovieCategory=MovieCategory.Drama
                    }

                });
                context.SaveChanges();
            }

            // Actor & Movie

            if (!context.Actors_Movies.Any())
            {
                context.Actors_Movies.AddRange(new List<Actor_Movie>()
                {
                    new Actor_Movie
                    {
                        ActorId=1,
                        MovieId=3
                    },
                    new Actor_Movie
                    {
                        ActorId=2,
                        MovieId=3
                    },

                    new Actor_Movie
                    {
                        ActorId=5,
                        MovieId=3
                    },

                    new Actor_Movie
                    {
                        ActorId=2,
                        MovieId=4
                    },

                    new Actor_Movie
                    {
                        ActorId=3,
                        MovieId=4
                    },

                    new Actor_Movie
                    {
                        ActorId=4,
                        MovieId=4
                    }

                });

                context.SaveChanges();
            }

        }

        // User and Role Seeding
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();


            // Roles
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));


            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            // Users
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string adminUserEmail = "admin@etickets.com";
            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
            if(adminUser == null)
            {
                var newAdminUser = new ApplicationUser
                {
                    FullName="Admin User",
                    UserName="admin-user",
                    Email= adminUserEmail,
                    EmailConfirmed=true,
                };
                await userManager.CreateAsync(newAdminUser,"Coding@1234?");
                await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            }

           
            string appUserEmail = "user@etickets.com";
            var appUser = await userManager.FindByEmailAsync(appUserEmail);
            if (appUser == null)
            {
                var newAppUser = new ApplicationUser
                {
                    FullName = "Application User",
                    UserName = "app-user",
                    Email = appUserEmail,
                    EmailConfirmed = true,
                };
                await userManager.CreateAsync(newAppUser, "Coding@1234?");
                await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
            }





        }
    }
}
