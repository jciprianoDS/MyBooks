using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyBooks.Data.Models;
using System.Linq;

namespace MyBooks.Data
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st Book Title",
                        Description = "1st Book Description",
                        IsRead = true,
                        DateTead = System.DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        CoverURL = "https...",
                        DateAdded = System.DateTime.Now
                    },
                    new Book()
                    {
                        Title = "2nd Book Title",
                        Description = "2nd Book Description",
                        IsRead = false,
                        Genre = "Biography",
                        CoverURL = "https...",
                        DateAdded = System.DateTime.Now
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
