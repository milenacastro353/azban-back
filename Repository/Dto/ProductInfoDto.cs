using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dto
{
    public class ProductInfoDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Sigle { get; set; }

        public string Gender { get; set; }

        public List<GenderDto> Genders { get; set; }

        public List<ColorDto> Colors { get; set; }

        public List<SizeDto> Sizes { get; set; }
    }
}
