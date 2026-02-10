using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itbook.Dtos;

namespace itbook.Interfaces
{
    public interface IBookService
    {
        Task<BookResponseDto?> GetAllAsync(string query, int page = 1);
        Task<BookDto?> GetByIsbnAsync(string isbn);
    }
}
