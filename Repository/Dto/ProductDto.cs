using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Product { get; set; }

        public string Initials { get; set; }

        public int SizeId { get; set; }

        public string Size { get; set; }

        public int ColorId { get; set; }

        public string Color { get; set; }

        public string Gender { get; set; }

        public int Quantity { get; set; }

        public string MainPrint { get; set; }

        public string SecundaryPrint { get; set; }

        public string Anotation { get; set; }

        public int StateId { get; set; }

        public string State { get; set; }

        public int ProccessStampId { get; set; }

        public bool ReadyProductBase { get; set; }

        public bool? ToDo { get; set; }
    }
}
