using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itbook.Data;
using itbook.Dtos;
using itbook.Interfaces;
using itbook.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itbook.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IBookService _bookService;

        public UserController(ApplicationDbContext context, IBookService bookService)
        {
            _context = context;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            // Get all users from db
            var users = await _context.Users.Select(u => u.ToUserDto()).ToListAsync();
            // Response all users
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById([FromRoute] int id)
        {
            // Check if user exists in db, if not return 404
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            // Response user
            return Ok(user.ToUserDto());
        }

        [HttpGet("like")]
        public async Task<ActionResult<List<LikeBookDto>>> GetAllLikeBook()
        {
            // Get all like books from db
            var likeBooks = await _context
                .LikeBooks.Include(lb => lb.User)
                .Select(lb => lb.ToLikeBookDto())
                .ToListAsync();
            // Response all like books
            return Ok(likeBooks);
        }

        [HttpGet("like/{id}")]
        public async Task<ActionResult<LikeBookDto>> GetLikeBookById([FromRoute] int id)
        {
            // Check if like book exists in db, if not return 404
            var likeBook = await _context
                .LikeBooks.Include(lb => lb.User)
                .FirstOrDefaultAsync(lb => lb.Id == id);
            if (likeBook == null)
            {
                return NotFound("Like book not found");
            }
            // Response like book
            return Ok(likeBook.ToLikeBookDto());
        }

        [HttpPost("like")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<LikeBookDto>> LikeBook(
            [FromBody] LikeBookRequestDto likeBookRequestDto
        )
        {
            // Check if book exists in api, if not return 404
            var book = await _bookService.GetByIsbnAsync(likeBookRequestDto.BookId);
            if (book == null)
            {
                return NotFound("Book not found");
            }
            // Check if user exists in db, if not return 404
            var user = await _context.Users.FindAsync(likeBookRequestDto.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            // Check if like book already exists in db, if not return 400
            var existingLikeBook = await _context.LikeBooks.FirstOrDefaultAsync(lb =>
                lb.UserId == likeBookRequestDto.UserId && lb.BookId == likeBookRequestDto.BookId
            );
            if (existingLikeBook != null)
            {
                return BadRequest("This book has already been liked");
            }
            // Save like book to db
            var likeBook = likeBookRequestDto.ToLikeBookFromCreateDto();
            _context.LikeBooks.Add(likeBook);
            await _context.SaveChangesAsync();
            // Response like book
            return Created("", likeBook.ToLikeBookDto());
        }

        [HttpDelete("like/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteLikeBook([FromRoute] int id)
        {
            // Check if like book exists in db, if not return 404
            var likeBook = await _context.LikeBooks.FindAsync(id);
            if (likeBook == null)
            {
                return NotFound("Like book not found");
            }
            // Delete like book from db
            _context.LikeBooks.Remove(likeBook);
            await _context.SaveChangesAsync();
            // Response like book deleted
            return NoContent();
        }
    }
}
