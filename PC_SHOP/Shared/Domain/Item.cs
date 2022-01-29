using CarRentalManagement.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PC_SHOP.Shared.Domain
{
    public class Item : BaseDomainModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int BrandID { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual List<ListItem> ListItems { get; set; }
        public virtual List<Request> Requests { get; set; }
    }
}
