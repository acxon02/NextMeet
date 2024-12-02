using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

public class NextMeetContext : DbContext
{
    public DbSet<Reserva> Reservas { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reserva>().ToTable("Reservas"); // Asegúrate de que la tabla se llame "Reservas"
        base.OnModelCreating(modelBuilder);
    }
}

