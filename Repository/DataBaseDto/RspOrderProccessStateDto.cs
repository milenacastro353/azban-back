using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataBaseDto
{
    public class RspOrderProccessStateDto
    {
        public int OrderId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public bool Payed { get; set; }

        public int CurrentOrderState { get; set; }

        public string ClientName { get; set; }

        public string ClientDocument { get; set; }

        public int StateId { get; set; }

        public string State { get; set; }

        public DateTime StateDate { get; set; }
    }
}
