using DDDExample.domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExample.Application.DTO
{
    public class ProductFilterDTO
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        
    }
}
