using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tarea1Final.Modelo
{
    public class Venta
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public double monto { get; set; }
        public bool estado { get; set; }
    }
}