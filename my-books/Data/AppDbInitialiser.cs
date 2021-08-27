using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;

namespace my_books.Data
{
	public class AppDbInitialiser
	{
		public static void Seed(IApplicationBuilder applicaitonBuilder)
		{
			using (var serviceScope = applicaitonBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

				if (!context.Books.Any())
				{
					context.Books.AddRange(new Book()
					{
						Title = "1stBook",
						Description = "1st description",
						IsRead = true,
						DateRead = DateTime.Now.AddDays(-10),
						Rate = 400,
						Genre = "Biography",
						CoverUrl = "test.com",
						DateAdded = DateTime.Now
					},
					new Book()
					{
						Title = "2ndBook",
						Description = "2nd description",
						IsRead = true,
						DateRead = DateTime.Now.AddDays(-20),
						Rate = 500,
						Genre = "Story",
						CoverUrl = "test.com",
						DateAdded = DateTime.Now
					});
					context.SaveChanges();
				}

			}
		}

	}
}
