using EntityFrameworkExtras.EFCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.StoreProcedure
{
    [StoredProcedure("CambiarEstadoEstampado")]
    public class SpChangeSttampState
    {
        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "idDetallePedido")]
        public int OrderDetailId { get; set; }

        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "idEstadoEstampado")]
        public int SttampState { get; set; }
    }
}
