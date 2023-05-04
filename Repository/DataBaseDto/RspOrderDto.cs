using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkExtras.EFCore;
namespace Repository.DataBaseDto
{
    public class RspOrderDto
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

        public Int64 Deposit { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime CreationDate { get; set; }
        
        public int ProductDetailId { get; set; }

        public int ProductId { get; set; }

        public string Product { get; set; }

        public string Initials { get; set; }

        public int SizeId { get; set; }

        public string Size { get; set; }

        public int ColorId { get; set; }

        public string Color { get; set; }

        public int Quantity { get; set; }

        public string Gender { get; set; }

        public string MainPrint { get; set; }

        public string SecundaryPrint { get; set; }

        public string Anotation { get; set; }

        public int ProccessStampId { get; set; }

        public bool ReadyProductBase { get; set; }

        public int NumImages { get; set; }

        public bool? ToDo { get; set; }
    }
}
