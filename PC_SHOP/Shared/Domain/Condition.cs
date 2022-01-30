using CarRentalManagement.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_SHOP.Shared.Domain
{
    public class Condition : BaseDomainModel
    {
        [Required]
        public string Name { get; set; }
    }
}
