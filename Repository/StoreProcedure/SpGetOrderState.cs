using EntityFrameworkExtras.EFCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.StoreProcedure
{

    [StoredProcedure("ObtenerEstadoPedidoPorDocumento")]
    public class SpGetOrderState
    {
        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "idPedido")]
        public int OrderId { get; set; }

        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "tipoDocumento")]
        public int DocumentTypeId { get; set; }

        [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "numeroDocumento")]
        public string DocumentNumber { get; set; }
    }
}
