using Microsoft.EntityFrameworkCore;
using mvcPractica01.Models;
namespace mvcPractica01.Models
{
    public class equiposDbContext : DbContext
    {
        public equiposDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<estados_equipo> estados_equipo { get; set; }
        public DbSet<estados_reserva> estados_reserva { get; set; }
        public DbSet<facultades> facultades { get; set; }
        public DbSet<tipo_equipo> tipo_equipo { get; set; }
        public DbSet<carreras> carreras { get; set; }
        public DbSet<mvcPractica01.Models.usuarios>? usuarios { get; set; }
    }
}
 