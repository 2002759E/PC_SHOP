using PC_SHOP.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_SHOP.Shared.Domain
{
    public class TransactionHistory
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string? ListedItemOwner { get; set; }
        public string? ListedItemName { get; set; }
        public string? ListedItemPrice { get; set; }
        public string? BuyerName { get; set; }
        public string? OfferType { get; set; }
        public int? OfferPrice { get; set; }
        public string? OfferItem { get; set; }
        public string? Status { get; set; }

    }
}
