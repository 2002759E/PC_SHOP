using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_SHOP.Shared.Domain
{
    public class Review
    {
        public int ReviewID { get; set; }
        public decimal Rating { get; set; }
        public string Title { get; set;}
        
        public virtual User{get;set;}
        
        public int UserID

        public DateTime CreatedAt { get; set; }
        

        
       
    }
}
