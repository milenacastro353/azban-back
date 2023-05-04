using EntityFrameworkExtras.EFCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.StoreProcedure
{
    [StoredProcedure("EliminarDireccion")]
    public class SpDeleteAddressDto
    {
        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "id")]
        public int Id { get; set; }
    }
}
