using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{

    [Table("Tallas")]
    public class Size
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Talla")]
        public string Value { get; set; }
    }
}
