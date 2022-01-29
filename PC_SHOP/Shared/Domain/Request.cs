using CarRentalManagement.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_SHOP.Shared.Domain
{
    public class Request : BaseDomainModel
    {
        public int OfferID { get; set; }
        public virtual Offer Offer { get; set; }
        public int? PaymentID { get; set; }
        public virtual Payment Payment { get; set; }
        public int? ItemID { get; set; }
        public virtual Item Item { get; set; }
        public int ListItemID { get; set; }
        public virtual ListItem ListItem { get; set; }
        
    }
}
