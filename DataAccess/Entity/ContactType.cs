using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class ContactType
    {
        [Key]
        public int Id { get; set; }

        [Column("MedioContacto")]
        public string Name { get; set; }
    }
}
