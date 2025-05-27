using MusicAut_HernandezMargot.Models;
using MusicAut_HernandezMargot.Data;
using Microsoft.EntityFrameworkCore;

namespace MusicAut_HernandezMargot.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Margot_ChinookContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Margot_ChinookContext>>()))
            {
                if (context.Reviews.Any())
                {
                    return;
                }
                context.Reviews.AddRange(
                    new Review
                    {
                        Title = "Great Album",
                        ReviewContent = "I really enjoyed this album",
                        Rating = 9,
                        ArtistId = 155
                    },
                    new Review
                    {
                        Title = "Ilike it",
                        ReviewContent = "I really enjoyed this album",
                        Rating = 7,
                        ArtistId = 212
                    }
                 );

                context.SaveChanges();

            }

        }
    }
}

