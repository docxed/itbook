using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itbook.Dtos
{
    public class LikeBookDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string BookId { get; set; } = string.Empty;
        public DateTime LikedDateTime { get; set; }
        public UserDto? User { get; set; }
    }
}
