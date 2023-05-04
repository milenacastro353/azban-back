using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Column("Nombre")]
        public string Name { get; set; }

        [Column("Descripcion")]
        public string Description { get; set; }

        [Column("Precio")]
        public decimal Price { get; set; }

        [Column("Sigla")]
        public string Sigle { get; set; }

        [Column("Genero")]
        public string Gender { get; set; }

        [Column("IdColor")]
        public int ColorId { get; set; }

        [Column("Color")]
        public string ColorName { get; set; }

        [Column("HexRef")]
        public string HexRef { get; set; }

        [Column("IdTalla")]
        public int SizeId { get; set; }

        [Column("Talla")]
        public string SizeName { get; set; }
    }
}
