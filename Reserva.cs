    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextMeet;

public class Reserva
{
    public int Id { get; set; }

    [Column("ClienteNombre")] // Asegúrate de que la columna se llama así en la base de datos
    public string NombreCliente { get; set; }

    [Column("ClienteCorreo")]
    public string CorreoCliente { get; set; }

    public DateTime Fecha { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }

    [Column("TipoHabitacion")] // Asegúrate de que el nombre de la columna sea correcto
    public string TipoSala { get; set; }

    [Column("PrecioTotal")] // Asegúrate de que el nombre de la columna sea correcto
    public decimal TotalPago { get; set; }
}

