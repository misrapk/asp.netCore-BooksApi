using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using my_books.Data;
using my_books.Data.Models;
using my_books.Data.Services;
using NUnit.Framework;

namespace my_books_tests
{
	public class PublishersServiceTest
	{
		private static DbContextOptions<AppDbContext> dbContextOptions= new DbContextOptionsBuilder<AppDbContext>()
			.UseInMemoryDatabase(databaseName: "BookDbTest")
			.Options;
		AppDbContext context;

		//create publisherservice type
		PublishersService publishersService;
		[OneTimeSetUp]
		public void Setup()
		{
			//make sure database is connected
			context = new AppDbContext(dbContextOptions);
			context.Database.EnsureCreated();


			//add some data to database
			SeedDatabase();
			publishersService = new PublishersService(context);
		}

		//unit test for get all publishers
		[Test]
		public void GetAllPublshers_WIthNoSortby_WithNosearchString_withNoPageNumber()
		{
			var result = publishersService.GetAllPublshers("", "", null);

			Assert.That(result.Count, Is.EqualTo(3));

			Assert.AreEqual(result.Count, 3);
		}

		//after test exectute then clearn up the data base

		[OneTimeTearDown]
		public void CleanUp()
		{
			context.Database.EnsureDeleted();
		}

		private void SeedDatabase()
		{
			var publishers = new List<Publisher>
			{
					new Publisher(){
						Id = 1,
						Name = "Publisher 1"
					},
					new Publisher(){
						Id = 2,
						Name = "Publisher 2"
					},
					new Publisher(){
						Id = 3,
						Name = "Publisher 3"
					},
			};
			context.Publishers.AddRange(publishers);

			var authors = new List<Author>
			{
					new Author(){
						Id = 1,
						Name = "Author 1"
					},
					new Author(){
						Id = 2,
						Name = "Author 2"
					},
					new Author(){
						Id = 3,
						Name = "Author 3"
					},
			};
			context.Authors.AddRange(authors);

			var books = new List<Book>
			{
					new Book(){
						Id = 1,
						Title = "Book 1 Title",
						Description = "Desc1",
						IsRead = true,
						Genre = "Genre1",
						CoverUrl = "link.html.com",
						DateAdded = DateTime.Now.AddDays(-10),
						PublisherID = 1
					},
					new Book(){
						Id = 2,
						Title = "Book 2 Title",
						Description = "Desc2",
						IsRead = false,
						Genre = "Genre2",
						CoverUrl = "link.html.com",
						DateAdded = DateTime.Now.AddDays(-10),
						PublisherID = 1
					},

			};
			context.Books.AddRange(books);

			var book_authors = new List<Book_Author>
			{
					new Book_Author(){
						Id = 1,
						BookId = 1,
						AuthorId = 1
					},
					new Book_Author(){
						Id = 2,
						BookId = 1,
						AuthorId = 2
					},
					new Book_Author(){
						Id = 3,
						BookId = 2,
						AuthorId = 2
					},

			};
			context.Books_Authors.AddRange(book_authors);

			context.SaveChanges();
		}

		
	}
}