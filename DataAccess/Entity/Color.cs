using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Color
    {
        [Key]
        public int Id { get; set; }

        [Column("Color")]
        public string Value { get; set; }

    }
}
