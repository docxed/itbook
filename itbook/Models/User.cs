using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace itbook.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Fullname { get; set; } = string.Empty;

        // Navigation Properties
        public List<LikeBook> LikeBooks { get; set; } = new List<LikeBook>();
    }
}
