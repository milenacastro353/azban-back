using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string Client { get; set; }

        public string Contact { get; set; }

        public int StateId { get; set; }

        public string State { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int DepartmentId { get; set; }

        public string Department { get; set; }

        public string City { get; set; }

        public int AddressId { get; set; }

        public string Address { get; set; }

        public int PaymentMethodId { get; set; }

        public string PaymentMethod { get; set; }

        public bool Deposited { get; set; }

        public bool Payed { get; set; }

        public int NumImages { get; set; }

        public Int64 Deposit { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime CreationDate { get; set; }

        public List<ProductDto> Products { get; set; }
    }
}
