using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class DocumentType
    {
        [Key]
        public int Id { get; set; }

        [Column("Nombre")]
        public string Name { get; set; }

        [Column("Abreviatura")]
        public string Abbreviation { get; set; }
    }
}
