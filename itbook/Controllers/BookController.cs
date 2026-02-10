using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using itbook.Dtos;
using itbook.Helpers;
using itbook.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itbook.Controllers
{
    [Authorize]
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{query}/{page}")]
        public async Task<ActionResult<BookResponseDto>> GetAll(
            [FromRoute] string query = "mysql",
            [FromRoute] int page = 1
        )
        {
            // Get all books from api, if failed return 400
            var data = await _bookService.GetAllAsync(query, page);
            if (data == null)
            {
                return BadRequest("Failed to get books from api");
            }
            // Sort books by title
            if (data.Books.Count > 1)
            {
                data.Books = data.Books.OrderBy(i => i.Title).ToList();
            }
            // Response books from api
            return Ok(data);
        }

        [HttpGet("{isbn}")]
        public async Task<ActionResult<BookDto>> GetByIsbn([FromRoute] string isbn)
        {
            // Get book by isbn from api, if failed return 400
            var data = await _bookService.GetByIsbnAsync(isbn);
            if (data == null)
            {
                return BadRequest("Failed to get book from api");
            }
            // Response book from api
            return Ok(data);
        }
    }
}
