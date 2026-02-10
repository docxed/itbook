using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace itbook.Dtos
{
    public class LikeBookRequestDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string BookId { get; set; } = string.Empty;
    }
}
