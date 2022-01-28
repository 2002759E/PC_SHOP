using CarRentalManagement.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_SHOP.Shared.Domain
{
    public class ListItem : BaseDomainModel
    {
        public int ItemID { get; set; }
        public virtual Item Item { get; set; }
        public virtual List<Request> Requests { get; set; }
    }
}
