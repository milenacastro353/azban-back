using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dto
{
    public class AddressDto
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public int DepartmentId { get; set; }

        public string City { get; set; }

        public string DepartmentName { get; set; }

        public string Addresse { get; set; }

        public string AddressePhone { get; set; }
    }
}
