using EntityFrameworkExtras.EFCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.StoreProcedure
{
    [StoredProcedure("CambiarExistenciaProductoBase")]
    public class SpSetProductBaseExist
    {
        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "idDetallePedido")]
        public int OrderDetailId { get; set; }

        [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "existeProductoBase")]
        public bool ProductBaseExist { get; set; }
    }
}
