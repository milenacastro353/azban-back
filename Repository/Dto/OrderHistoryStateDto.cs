using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dto
{
    public class OrderHistoryStateDto
    {
        public int StateId { get; set; }

        public string State { get; set; }

        public DateTime StateDate { get; set; }
    }
}
