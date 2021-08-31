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
	public class PublishersController : ControllerBase
	{
		public PublishersService _publishersService;
		public PublishersController(PublishersService publishersService)
		{
			_publishersService = publishersService;
		}

		[HttpPost("add-publisher")]
		public IActionResult AddBook([FromBody] PublisherVM publisher)
		{
			_publishersService.AddPublisher(publisher);
			return Ok();
		}

		[HttpGet("getpublisherbookswithauthors/{id}")]
		public IActionResult GetPublisherData(int id)
		{
			var _res = _publishersService.GetPublisherData(id);
			return Ok(_res);
		}
	}
}
