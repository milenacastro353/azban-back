using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dto
{
    public class ClientDto
    {
        public int Id { get; set; }

        public int IdDocumentType { get; set; }

        public string Document { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int IdContactType { get; set; }

        public string ContactValue { get; set; }

        public List<AddressDto> Adresses { get; set; }
    }
}
