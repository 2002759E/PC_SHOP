using PC_SHOP.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PC_SHOP.Shared.Domain
{
    public class Item : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name does not meet length requirements")]
        public string Name { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Description does not meet length requirements")]
        public string Description { get; set; }
        [Required]
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        [Required]
        public int? ConditionID { get; set; }
        public virtual Condition Condition { get; set; }
        [Required]
        public int? BrandID { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual List<ListItem> ListItems { get; set; }
        public virtual List<TradeRequest> TradeRequests { get; set; }
    }
}
