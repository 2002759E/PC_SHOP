using PC_SHOP.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_SHOP.Shared.Domain
{
    public class TradeRequest : BaseDomainModel
    {

        [Required]
        public int? ItemID { get; set; }
        public virtual Item Item { get; set; }
        [Required]
        public int? ListItemID { get; set; }
        public virtual ListItem ListItem { get; set; }
        
    }
}
