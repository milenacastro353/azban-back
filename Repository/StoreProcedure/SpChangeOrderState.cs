using EntityFrameworkExtras.EFCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.StoreProcedure
{
    [StoredProcedure("CambiarEstado")]
    public class SpChangeOrderState
    {
        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "idPedido")]
        public int OrderId { get; set; }

        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "idEstado")]
        public int StateId { get; set; }
    }
}
