using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace itbook.Dtos
{
    public class RegisterRequestDto
    {
        [Required]
        [MaxLength(20)]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Fullname { get; set; } = string.Empty;
    }
}
