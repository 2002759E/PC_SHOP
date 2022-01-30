using CarRentalManagement.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PC_SHOP.Shared.Domain
{
    public class ListItem : BaseDomainModel
    {
        [Required]
        public double? Price { get; set; }
        [Required]
        public int? ItemID { get; set; }
        public virtual Item Item { get; set; }
        public virtual List<Request> Requests { get; set; }
    }
}
