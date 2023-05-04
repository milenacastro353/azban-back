using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dto
{
    public class OrderHistoryDto
    {
        public OrderHistoryDto()
        {
            this.States = new List<OrderHistoryStateDto>();
            this.DeliveryDate = new DateTime[2];
        }

        public int OrderId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime[] DeliveryDate { get; set; }

        public bool Payed { get; set; }

        public int CurrentOrderState { get; set; }

        public string ClientName { get; set; }

        public string ClientDocument { get; set; }

        public List<OrderHistoryStateDto> States { get; set; }
    }
}
