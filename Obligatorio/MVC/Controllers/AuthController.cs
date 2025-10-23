using Compartido.DTOs.UsuarioDTOs;
using LogicaAplicacion.InterfaceCasosUso.UsuarioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MVC.Models.Usuario;

namespace MVC.Controllers
{
    public class AuthController : Controller
    {
        private ILoginUsuario CULoginUsuario { get; set; }

        public AuthController(ILoginUsuario cULoginUsuario)
        {
            CULoginUsuario = cULoginUsuario;
        }
        // GET: AuthController/Login
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        // POST: AuthController/HttpPost/Login/5
        [HttpPost]
        public IActionResult Login(LoginUsuarioViewModel loginUsuarioVM)
        {
            try
            {
                // Busco al usuario, si no existe explota
                UsuarioEnteroDTO Buscado = CULoginUsuario.Ejecutar(loginUsuarioVM.Email, loginUsuarioVM.Contrasenia);
                
                if (Buscado.Rol == Rol.Cliente)
                {
                    throw new UsuarioException("Los clientes no pueden loguearse");
                }
                else
                {
                    // Reviso que el usuario este activo
                    if (Buscado.Estado == true)
                    {
                        HttpContext.Session.SetInt32("LogueadoId", Buscado.Id);
                        HttpContext.Session.SetString("LogueadoRol", Buscado.Rol.ToString());
                        HttpContext.Session.SetString("LogueadoNombre", Buscado.Nombre);
                        HttpContext.Session.SetString("LogueadoApellido", Buscado.Apellido);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // Le impido loguearse
                        return RedirectToAction("NoAutorizado", "Auth");
                    }

                }
            }
            catch (UsuarioException ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
                return View();
            }
        }

        // GET: AuthController/Logout
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        // GET: AuthController/NoAutorizado
        [HttpGet]
        public IActionResult NoAutorizado()
        {
            return View();
        }


    }
}
