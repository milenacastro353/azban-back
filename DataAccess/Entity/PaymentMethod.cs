using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class PaymentMethod
    {
        [Key]
        public Byte Id { get; set; }

        [Column("Nombre")]
        public string Name { get; set; }
    }
}
