using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace itbook.Dtos
{
    public class BookDto
    {
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Isbn13 { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }

    public class BookResponseDto
    {
        public string Error { get; set; } = "0";
        public string Total { get; set; } = "0";
        public string Page { get; set; } = "1";
        public List<BookDto> Books { get; set; } = new List<BookDto>();
    }
}
