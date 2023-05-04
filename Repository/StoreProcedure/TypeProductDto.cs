using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkExtras.EFCore;

namespace Repository.StoreProcedure
{
    [UserDefinedTableType("DtDetallePedido")]
    public class TypeProductDto
    {
        [UserDefinedTableTypeColumn(1)]
        public int Id { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public int ColorId { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public int SizeId { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public string MainPrint { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public string SecundaryPrint { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public string Observations { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public int Quantity { get; set; }

        [UserDefinedTableTypeColumn(8)]
        public int Price { get; set; }

        [UserDefinedTableTypeColumn(9)]
        public int PriceVaration { get; set; }

        [UserDefinedTableTypeColumn(10)]
        public int GenderId { get; set; }
    }
}
