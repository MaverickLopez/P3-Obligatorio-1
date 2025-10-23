using LogicaNegocio.InterfaceRepositorios;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.ImplementacionCasosUso.EnvioCU;
using LogicaAplicacion.InterfaceCasosUso.EnvioCU;
using LogicaAplicacion.InterfaceCasosUso.UsuarioCU;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAccesoDatos;
using Microsoft.EntityFrameworkCore;
using LogicaAplicacion.InterfaceCasosUso.AuditoriaCU;
using LogicaAplicacion.ImplementacionCasosUso.AuditoriaCU;
using LogicaAplicacion.InterfaceCasosUso.AgenciaCU;
using LogicaAplicacion.ImplementacionCasosUso.AgenciaCU;
using LogicaAplicacion.InterfaceCasosUso.ComentarioCU;
using LogicaAplicacion.ImplementacionCasosUso.ComentarioCU;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
