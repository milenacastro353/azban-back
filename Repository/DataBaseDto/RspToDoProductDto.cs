using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataBaseDto
{
    public class RspToDoProductDto
    {
        public int ProductDetailId { get; set; }

        public int Quantity { get; set; }

        public string Gender { get; set; }

        public bool ToDo { get; set; }

        public bool WasProducced { get; set; }

        public DateTime CreationDate { get; set; }

        public int IdEstado { get; set; }

        public int ProductId { get; set; }

        public string Product { get; set; }

        public int SizeId { get; set; }

        public string Size { get; set; }

        public int ColorId { get; set; }

        public string Color { get; set; }
    }
}
