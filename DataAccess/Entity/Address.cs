using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Column("IdCliente")]
        public int ClientId { get; set; }

        [Column("Direccion")]
        public string AddressValue { get; set; }

        [Column("IdDepartamento")]
        public int DepartmentId { get; set; }

        [Column("CiudadMunicipio")]
        public string City { get; set; }

        [Column("Departamento")]
        public string DepartmentName { get; set; }

        [Column("Destinatario")]
        public string Addresse { get; set; }

        [Column("CelularDestinatario")]
        public string AddressePhone { get; set; }
    }
}
