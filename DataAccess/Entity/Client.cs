using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Column("Nombre")]
        public string Name { get; set; }

        [Column("Celular")]
        public string Phone { get; set; }

        public string Email { get; set; }

        [Column("IdDireccion")]
        public int AddressId { get; set; }

        [Column("Direccion")]
        public string Address { get; set; }

        [Column("IdDepartamento")]
        public int DepartmentId { get; set; }

        [Column("CiudadMunicipio")]
        public string City { get; set; }

        [Column("NombreDepartamento")]
        public string DepartmentName { get; set; }

        [Column("Destinatario")]
        public string Addresse { get; set; }

        [Column("CelularDestinatario")]
        public string AddressePhone { get; set; }

        [Column("IdTipoContacto")]
        public int ContactId { get; set; }

        [Column("MedioContacto")]
        public string ContactValue { get; set; }

    }
}
