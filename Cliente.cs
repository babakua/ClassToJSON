using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassToJSON
{
    public class Cliente
    {
        public int idCodigo { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }

        public int edad { get; set; }

        public Factura factura { get; set; }
        public Pago pago { get; set; }
    }
}
