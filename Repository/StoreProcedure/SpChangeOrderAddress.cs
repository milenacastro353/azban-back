using EntityFrameworkExtras.EFCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.StoreProcedure
{
    [StoredProcedure("CambiarDireccionAPedido")]
    public class SpChangeOrderAddress
    {
        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "idPedido")]
        public int OrderId { get; set; }

        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "idDireccion")]
        public int SAddressId { get; set; }
    }
}
