using EntityFrameworkExtras.EFCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.StoreProcedure
{
    [StoredProcedure("CambiarConfeccionProductoBase")]
    public class SpSetProductionClothes
    {
        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "idDetallePedido")]
        public int OrderDetailId { get; set; }
    }
}
