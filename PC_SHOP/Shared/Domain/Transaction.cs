using PC_SHOP.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_SHOP.Shared.Domain
{
    public class Transaction : BaseDomainModel
    {
        public string ListedItemOwner { get; set; }
        public string ListedItemName { get; set; }
        public double? ListedItemPrice { get; set; }
        public string BuyerName { get; set; }
        public string TransactionType { get; set; }
        public double? OfferPrice { get; set; }
        public string? OfferItem { get; set; }
        public string Status { get; set; }

    }
}
