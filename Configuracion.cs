using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nextmeet
{
    public static class Configuracion
    {
        public static string TipoHabitacion { get; set; }
        public static decimal PrecioHora { get; set; }
        public static List<string> HorariosDisponibles { get; set; } = new List<string>();
        public static List<string> Complementos { get; set; } = new List<string>();
    }

}
