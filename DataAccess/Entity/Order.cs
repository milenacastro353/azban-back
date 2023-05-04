using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Order
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string Name { get; set; }
    }
}
