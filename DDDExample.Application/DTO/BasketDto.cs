using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExample.Application.DTO
{
    public class BasketDto
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public int Adet { get; set; }
    }
}
