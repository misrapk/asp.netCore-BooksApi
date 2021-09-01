using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.ActionResults;
using my_books.Data.Models;
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

		[HttpGet("getAllPublishers")]
		public IActionResult GetAllPublishers(string sortBy, string searchString, int pgNumber)
		{
			try
			{
				var _result = _publishersService.GetAllPublshers(sortBy, searchString, pgNumber);
				return Ok(_result);
			}
			catch (Exception)
			{

				return BadRequest("Cant Load Publishers");
			}
		}

		[HttpPost("add-publisher")]
		public IActionResult AddBook([FromBody] PublisherVM publisher)
		{
			_publishersService.AddPublisher(publisher);
			return Ok();
		}

		//get publisher by id
		[HttpGet("getPublisherbyid/{id}")]
		public IActionResult GetPublisherById(int id)
		{
			var _response = _publishersService.GetPublisherById(id);
			if (_response != null)
			{
				return Ok(_response);
				//var _responseobj = new CustomActionResultVM()
				//{
				//	Publisher = _response
				//};
				//return new CustomActionResult(_responseobj);
			}
			else
			{
				return NotFound();
				//var _responseobj = new CustomActionResultVM()
				//{
				//	Exception = new Exception("This is publisher controller")
				//};
				//return new CustomActionResult(_responseobj);
			}
		}

		[HttpGet("getpublisherbookswithauthors/{id}")]
		public IActionResult GetPublisherData(int id)
		{
			var _res = _publishersService.GetPublisherData(id);
			return Ok(_res);
		}

		[HttpDelete("deletePublisherById/{id}")]
		public IActionResult DeletePublisherById(int id)
		{
			_publishersService.DeletePublisherById(id);
			return Ok();
		}
	}
}
