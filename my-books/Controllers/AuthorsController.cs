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
	public class AuthorsController : ControllerBase
	{
		private AuthorsService _authorsService;

		public AuthorsController(AuthorsService authorsService)
		{
			_authorsService = authorsService;
		}

		[HttpPost("add-author")]
		public IActionResult AddBook([FromBody] AuthorVM author)
		{
			_authorsService.AddAuthor(author);
			return Ok();
		}

		[HttpGet("getAuthorsWithBook/{id}")]
		public IActionResult GetAuthorWithBooks(int id)
		{
			var response = _authorsService.GetAuthorsWithBooks(id);

			return Ok(response);
		}
	}
}
