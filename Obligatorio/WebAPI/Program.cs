
using LogicaAccesoDatos.Repositorios;
using LogicaAccesoDatos;
using LogicaAplicacion.ImplementacionCasosUso.AgenciaCU;
using LogicaAplicacion.ImplementacionCasosUso.AuditoriaCU;
using LogicaAplicacion.ImplementacionCasosUso.ComentarioCU;
using LogicaAplicacion.ImplementacionCasosUso.EnvioCU;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAplicacion.InterfaceCasosUso.AgenciaCU;
using LogicaAplicacion.InterfaceCasosUso.AuditoriaCU;
using LogicaAplicacion.InterfaceCasosUso.ComentarioCU;
using LogicaAplicacion.InterfaceCasosUso.EnvioCU;
using LogicaAplicacion.InterfaceCasosUso.UsuarioCU;
using LogicaNegocio.InterfaceRepositorios;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgenciaEF>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvioEF>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoriaEF>();

            builder.Services.AddScoped<IAltaAgencia, AltaAgencia>();
            builder.Services.AddScoped<IMostrarAgencia, MostrarAgencia>();
            builder.Services.AddScoped<IBuscarAgencia, BuscarAgencia>();
            builder.Services.AddScoped<IEditarAgencia, EditarAgencia>();

            builder.Services.AddScoped<IAltaEnvioComun, AltaEnvioComun>();
            builder.Services.AddScoped<IAltaEnvioUrgente, AltaEnvioUrgente>();
            builder.Services.AddScoped<IFinalizarEnvio, FinalizarEnvio>();
            builder.Services.AddScoped<IMostrarEnvio, MostrarEnvio>();
            builder.Services.AddScoped<IBuscarEnvio, BuscarEnvio>();
            builder.Services.AddScoped<IAltaComentario, AltaComentario>();
            builder.Services.AddScoped<IBuscarEnvioNumeroTracking, BuscarEnvioNumeroTracking>();

            builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
            builder.Services.AddScoped<IBorrarUsuario, BorrarUsuario>();
            builder.Services.AddScoped<IEditarUsuario, EditarUsuario>();
            builder.Services.AddScoped<ILoginUsuario, LoginUsuario>();
            builder.Services.AddScoped<IMostrarUsuario, MostrarUsuario>();
            builder.Services.AddScoped<IBuscarUsuario, BuscarUsuario>();

            builder.Services.AddScoped<IAltaAuditoria, AltaAuditoria>();

            string cadenaConexion = builder.Configuration.GetConnectionString("CadenaConexion");
            builder.Services.AddDbContext<ObligatorioContext>
                (opt => opt.UseSqlServer(cadenaConexion));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt=>opt.IncludeXmlComments("WebAPI.xml"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
