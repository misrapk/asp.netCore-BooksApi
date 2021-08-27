using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		public BooksService _bookService;
		public BooksController(BooksService booksService)
		{
			_bookService = booksService;
		}

		[HttpGet("get-all-books")]
		public IActionResult GetAllBooks()
		{
			var allBooks = _bookService.GetAllBooks();
			return Ok(allBooks);
		}

		[HttpGet("get-book-by-id/{id}")]
		public IActionResult GetBookbyId(int id)
		{
			var singleBook = _bookService.GetBookbyId(id);
			return Ok(singleBook);
		}

		[HttpPost("add-book")]
		public IActionResult AddBook([FromBody] BookVM book)
		{
			_bookService.AddBook(book);
			return Ok();
		}

		[HttpPut("update-book-by-id/{id}")]
		public IActionResult UpdaeBookById(int id, [FromBody] BookVM book)
		{
			var updatedBook = _bookService.UpdateBookById(id, book);
			return Ok(updatedBook);
		}
		[HttpDelete("delete-book-by-id/{id}")]
		public IActionResult DeleteBookbyId(int id)
		{
			_bookService.DeleteBookbyId(id);
			return Ok();
		}
	}
}
