using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TravelerBlog.Persistence.Data
{
    public class TravelerBlogDbContext : IdentityDbContext<User>
    {
        public TravelerBlogDbContext(DbContextOptions<TravelerBlogDbContext> options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationPicture> LocationPictures { get; set; }
        public DbSet<FlagPicture> FlagPictures { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Advice> Advices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = new Guid("7e21177b-f8dd-448b-9a42-55e7336b1881"),
                    CountryName = "Turkey",
                    Description = "Turkey,[a] officially the Republic of Türkiye,[b] is a transcontinental country located mainly on the Anatolian Peninsula in Western Asia, with a small portion on the Balkan Peninsula in Southeast Europe. It shares borders with the Black Sea to the north; Georgia to the northeast; Armenia, Azerbaijan, and Iran to the east; Iraq to the southeast; Syria and the Mediterranean Sea to the south; the Aegean Sea to the west; and Greece and Bulgaria to the northwest. Cyprus is located off the south coast. Turks form the vast majority of the nation's population and Kurds are the largest minority.[4] Ankara is Turkey's capital, while Istanbul is its largest city and financial centre.",
                    IsActive = true,
                    IsDeleted = false,
                });

            builder.Entity<FlagPicture>().HasData(
                new FlagPicture
                {
                    Id = new Guid("7e21177b-f8dd-448b-9a42-55e7336b1881"),
                    FileName = "https://www.kitapgunu.com/u/kitapgunu/img/c/t/u/turk-bayragi-200x300cma8781fddae7a2d3d55e9dc27dfd4e861.jpg",
                    CreatedDate = DateTime.UtcNow
                }) ;


            builder.Entity<Location>().HasData(

                    new Location
                    {
                        Id = new Guid("2db8c9d8-40a1-445c-bd3e-f126cdf49352"),
                        LocationName = "Pamukkale",
                        Description = "Kent Kaplıcaları ve akan sulardan kalan karbonat minerallerin teraslarını, travertenlerini kapsamaktadır.",
                        City = "Denizli",
                        Ditrict = String.Empty,
                        CountryId = new Guid("7e21177b-f8dd-448b-9a42-55e7336b1881"),
                        IsActive = true,
                        IsDeleted = false
                    },
                    new Location
                    {
                        Id = new Guid("7583ba2d-1c79-48d0-b49d-fc973aa0a808"),
                        LocationName = "Topkapi Sarayi",
                        Description = "Topkapı Sarayı, İstanbul Sarayburnu'nda, Osmanlı İmparatorluğu'nun 600 yıllık tarihinin 400 yılı boyunca, devletin idare merkezi olarak kullanılan ve Osmanlı padişahlarının yaşadığı saraydır. ",
                        City = "Istanbul",
                        Ditrict = "Fatih",
                        CountryId = new Guid("7e21177b-f8dd-448b-9a42-55e7336b1881"),
                        IsActive = true,
                        IsDeleted = false

                    },
                     new Location
                     {
                         Id = new Guid("3714d51f-f691-4c53-a815-9a136a6c3821"),
                         LocationName = "Beylerbeyi Sarayi",
                         Description = "Beylerbeyi Sarayı, İstanbul'un Üsküdar ilçesinin Beylerbeyi semtinde bulunan ve Sultan Abdülaziz tarafından 1861-1865 yıllarında mimar Sarkis Balyan'a yaptırılan saraydır.",
                         City = "Istanbul",
                         Ditrict = "Uskudar",
                         CountryId = new Guid("7e21177b-f8dd-448b-9a42-55e7336b1881"),
                         IsActive = true,
                         IsDeleted = false

                     });
                


            builder.Entity<LocationPicture>().HasData(

             new LocationPicture
             {
                 Id = new Guid("e96ecdee-1207-4bc4-a03a-4fb1143b5f6e"),
                 FileName = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c6/Pamukkale_02.jpg/1280px-Pamukkale_02.jpg",
                 IsActive = true,
                 IsDeleted = false,
                 LocationId = new Guid("2db8c9d8-40a1-445c-bd3e-f126cdf49352")
             },
             new LocationPicture
             {
                 Id = new Guid("8d65f867-353c-4afe-8dcb-be36012fb2f4"),
                 FileName = "https://i4.hurimg.com/i/hurriyet/75/1110x740/5bc6d94218c773222c635a60.jpg",
                 IsActive = true,
                 IsDeleted = false,
                 LocationId = new Guid("7583ba2d-1c79-48d0-b49d-fc973aa0a808")
             },
              new LocationPicture
              {
                  Id = new Guid("219e963c-1ae2-4b03-93fe-9cde43df4df6"),
                  FileName = "https://istanbeautiful.com/tr/wp-content/uploads/beylerbeyi-palace.jpg",
                  IsActive = true,
                  IsDeleted = false,
                  LocationId = new Guid("3714d51f-f691-4c53-a815-9a136a6c3821")
              });

            builder.Entity<Post>().HasData(
                    new Post
                    {
                        Id = new Guid("84ae7470-0ad0-4bdb-bbc7-e5ff80a70167"),
                        LocationId = new Guid("2db8c9d8-40a1-445c-bd3e-f126cdf49352"),
                        Title = "This is Pamukkale's post title",
                        Content= "Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
                        SendDate = DateTime.UtcNow,
                        Name = "Traveler Boy",
                        EmailAddress= "john@mail.com"
                    },
                    new Post
                    {
                        Id = new Guid("87e7af76-4d0d-4c78-bd78-5d275445f647"),
                        LocationId = new Guid("7583ba2d-1c79-48d0-b49d-fc973aa0a808"),
                        Title = "This is Topkapi Sarayi's post title",
                        Content = "Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
                        SendDate = DateTime.UtcNow,
                        Name = "Traveler Boy",
                        EmailAddress = "john@mail.com",
                    },
                    new Post
                    {
                        Id = new Guid("65730b92-fa1c-49e4-8c32-4fad8d941540"),
                        LocationId = new Guid("3714d51f-f691-4c53-a815-9a136a6c3821"),
                        Title = "This is Beylerbeyi Sarayi's post title",
                        Content = "Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
                        SendDate = DateTime.UtcNow,
                        Name = "Traveler Boy",
                        EmailAddress = "john@mail.com",
                    }
                );

           
           base.OnModelCreating(builder);
        }

    }
}
