using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBooks.ActionResults;
using MyBooks.Data.Models;
using MyBooks.Data.Services;
using MyBooks.Data.ViewModels;
using MyBooks.Exceptions;
using System;

namespace MyBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publishersService;
        private readonly ILogger<PublishersController> _logger;

        public PublishersController(PublishersService publishersService, ILogger<PublishersController> logger)
        {
            _publishersService = publishersService;
            _logger = logger;
        }

        [HttpGet("GetAllPublishers")]
        public IActionResult GetAllPublishers(string sortBy, string searchString, int pageNumber)
        {
            try
            {
                _logger.LogInformation("this is just a log in GetAllPublishers");
                var _result = _publishersService.GetAllPublishers(sortBy, searchString, pageNumber);

                return Ok(_result);
            }
            catch (Exception)
            {
                return BadRequest("sorry, we could not load the publishers");
            }
        }

        [HttpPost("AddPublisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                var newPublisher = _publishersService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher name: {ex.PublisherName}");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPublisherById/{Id}")]
        public IActionResult GetPublisherById(int Id)
        {
            var _response = _publishersService.GetPublisherById(Id);

            if(_response != null)
            {
                return Ok(_response);
                //var _responseObj = new CustomActionResultVM()
                //{
                //    Publisher = _response
                //};

                //return new CustomActionResult(_responseObj);
            }
            else
            {
                //var _responseObj = new CustomActionResultVM()
                //{
                //    Exception = new Exception("This is coming from publishers controller")
                //};

                //return new CustomActionResult(_responseObj);

                return NotFound();
            }
        }

        [HttpGet("GetPublisherBooksWithAuthors/{Id}")]
        public IActionResult GetPublisherData(int Id)
        {
            var _response = _publishersService.GetPublisherData(Id);
            return Ok(_response);
        }

        [HttpDelete("DeletePublisherById/{Id}")]
        public IActionResult DeletePublisherById(int Id)
        {
            try
            {
                _publishersService.DeletePublisherById(Id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
