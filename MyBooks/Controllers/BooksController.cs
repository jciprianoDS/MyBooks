using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.Services;
using MyBooks.Data.ViewModels;

namespace MyBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;
        public BooksController(BooksService bookService)
        {
            _booksService = bookService;
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("GetBookById/{Id}")]
        public IActionResult GetBookById(int Id)
        {
            var book = _booksService.GetBookById(Id);
            return Ok(book);
        }

        [HttpPost("AddBookWithAuthors")]
        public IActionResult AddBookWithAuthors([FromBody]BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpPut("UpdateBookById/{Id}")]
        public IActionResult UpdateBookById(int Id, [FromBody]BookVM book)
        {
            var updatedbook = _booksService.UpdateBookById(Id, book);
            return Ok(updatedbook);
        }

        [HttpDelete("DeleteBookByID/{Id}")]
        public IActionResult DeleteBookByID(int Id)
        {
            _booksService.DeleteBookById(Id);
            return Ok();
        }
    }
}
