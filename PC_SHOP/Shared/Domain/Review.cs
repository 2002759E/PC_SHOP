using PC_SHOP.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_SHOP.Shared.Domain
{
    public class Review : BaseDomainModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 to 10.")]
        public int? Rating { get; set; }
    }
}
