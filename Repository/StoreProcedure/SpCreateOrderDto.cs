using EntityFrameworkExtras.EFCore;
using Repository.StoreProcedure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.StoreProcedure
{
    [StoredProcedure("CrearPedidos")]
    public class SpCreateOrderDto
    {
        public int Id { get; set; }

        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "idCliente")]
        public int ClientId { get; set; }

        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "idMediosPago")]
        public int PaymentMethodId { get; set; }

        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "idDireccionEntrega")]
        public int AddressId { get; set; }

        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "descuentos")]
        public int Discount { get; set; }

        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "precioTotal")]
        public int TotalPrice { get; set; }

        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "abono")]
        public int Deposit { get; set; }

        [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "abonado")]
        public bool Deposited { get; set; }

        [StoredProcedureParameter(SqlDbType.Bit, ParameterName = "pagado")]
        public bool PaidOut { get; set; }

        [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "tProducto")]
        public List<TypeProductDto> Products { get; set; }

        [StoredProcedureParameter(SqlDbType.Int, ParameterName = "numImagenes")]
        public int numImages { get; set; }

        public List<ImageBase64Data> Images { get; set; }
    }

    public class ImageBase64Data
    {
        public string Base64 { get; set; }

        public string Format { get; set; }
    }
}
