using EntityFrameworkExtras.EFCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.StoreProcedure
{
    [StoredProcedure("ObtenerPedidoPorId")]
    public class SpGetOrderById
    {
        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "idPedido")]
        public int OrderId { get; set; }
    }
}
