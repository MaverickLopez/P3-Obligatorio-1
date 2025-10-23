using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos
{
    public class ObligatorioContext : DbContext
    {
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Comun> Comunes { get; set; }
        public DbSet<Urgente> Urgentes { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }

        public ObligatorioContext(DbContextOptions options) : base(options)
        {

        }

        //Introducing FOREIGN KEY constraint 'FK_Curso_Usuario_UsuarioId' on table 'Curso' may cause cycles or multiple cascade paths.
        //Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
        //Could not create constraint or index.See previous errors.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Envio>().HasOne(c => c.Empleado).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Envio>().HasOne(c => c.Cliente).WithMany().OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }

    }
}
