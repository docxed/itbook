using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace itbook.Models
{
    public class LikeBook
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string BookId { get; set; } = string.Empty; // ISBN
        public DateTime LikedDateTime { get; set; } = DateTime.Now;

        // Navigation Properties
        public User? User { get; set; }
    }
}
