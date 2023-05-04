using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dto
{
    public class ListsDto
    {
        public List<DocumentType> DocumentTypes { get; set; }

        public List<ContactType> ContactTypes { get; set; }

        public List<PaymentMethod> PaymentMethods { get; set; }

        public List<Deparment> Departments { get; set; }
    }
}
