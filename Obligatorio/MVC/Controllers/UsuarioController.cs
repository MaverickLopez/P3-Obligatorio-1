using Compartido.DTOs.AuditoriaDTOs;
using Compartido.DTOs.UsuarioDTOs;
using LogicaAplicacion.InterfaceCasosUso.AuditoriaCU;
using LogicaAplicacion.InterfaceCasosUso.UsuarioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Usuario;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private IAltaUsuario CUAltaUsuario { get; set; }
        private IMostrarUsuario CUMostrarUsuario { get; set; }
        private IBuscarUsuario CUBuscarUsuario { get; set; }
        private IEditarUsuario CUEditarUsuaro { get; set; }
        private IBorrarUsuario CUBorrarUsuario { get; set; }
        private IAltaAuditoria CUAltaAuditoria { get; set; }

        public UsuarioController(IAltaUsuario cUAltaUsuario,
            IMostrarUsuario cUMostrarUsuario,
            IBuscarUsuario cUBuscarUsuario,
            IEditarUsuario cUEditarUsuaro,
            IBorrarUsuario cUBorrarUsuario,
            IAltaAuditoria cUAltaAuditoria)
        {
            CUAltaUsuario = cUAltaUsuario;
            CUMostrarUsuario = cUMostrarUsuario;
            CUBuscarUsuario = cUBuscarUsuario;
            CUEditarUsuaro = cUEditarUsuaro;
            CUBorrarUsuario = cUBorrarUsuario;
            CUAltaAuditoria = cUAltaAuditoria;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null
                && HttpContext.Session.GetString("LogueadoRol") != "Funcionario")
            {
                List<MostrarUsuarioDTO> mostrarUsuariosDTO = CUMostrarUsuario.Ejecutar();
                List<MostrarUsuarioViewModel> mostrarUsuariosVM = new List<MostrarUsuarioViewModel>();

                foreach (MostrarUsuarioDTO m in mostrarUsuariosDTO)
                {
                    MostrarUsuarioViewModel mostrarUsuarioVM = new MostrarUsuarioViewModel()
                    {
                        Id = m.Id,
                        Nombre = m.Nombre,
                        Apellido = m.Apellido,
                        Email = m.Email,
                        Contrasenia = m.Contrasenia,
                        Rol = m.Rol,
                        Estado = m.Estado
                    };
                    mostrarUsuariosVM.Add(mostrarUsuarioVM);
                }

                return View(mostrarUsuariosVM);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null
                && HttpContext.Session.GetString("LogueadoRol") != "Funcionario")
            {
                return View();
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuarioVM)
        {
            try
            {
                int? LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
                if (ModelState.IsValid && HttpContext.Session.GetString("LogueadoRol") != "Funcionario")
                {
                    UsuarioDTO usuarioDTO = new UsuarioDTO()
                    {
                        Nombre = usuarioVM.Nombre,
                        Apellido = usuarioVM.Apellido,
                        Email = usuarioVM.Email,
                        Contrasenia = usuarioVM.Contrasenia,
                        Rol = usuarioVM.Rol
                    };

                    AuditoriaDTO auditoriaDTO = new AuditoriaDTO()
                    {
                        Accion = "Nuevo usuario creado",
                        Fecha = DateTime.Now,
                        IdEmpleado = (int)HttpContext.Session.GetInt32("LogueadoId")
                    };

                    CUAltaUsuario.Ejecutar(usuarioDTO);
                    CUAltaAuditoria.Ejecutar(auditoriaDTO);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (UsuarioException ex)
            {
                ViewBag.msg = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Error en los datos";
            }
            return View();
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null
                && HttpContext.Session.GetString("LogueadoRol") != "Funcionario")
            {
                MostrarUsuarioViewModel usuarioVM = null;
                try
                {
                    if (id <= 0)
                    {
                        throw new UsuarioException("Id incorrecto");
                    }
                    MostrarUsuarioDTO usuarioDTO = CUBuscarUsuario.Ejecutar(id);
                    usuarioVM = new MostrarUsuarioViewModel()
                    {
                        Id = usuarioDTO.Id,
                        Nombre = usuarioDTO.Nombre,
                        Apellido = usuarioDTO.Apellido,
                        Email = usuarioDTO.Email,
                        Contrasenia = usuarioDTO.Contrasenia,
                        Rol = usuarioDTO.Rol,
                        Estado = usuarioDTO.Estado
                    };
                }
                catch (UsuarioException ex)
                {
                    ViewBag.msg = ex.Message;
                }

                return View(usuarioVM);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MostrarUsuarioViewModel usuarioVM)
        {
            try
            {
                int? LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
                if (ModelState.IsValid && HttpContext.Session.GetString("LogueadoRol") != "Funcionario")
                {
                    MostrarUsuarioDTO usuarioDTO = new MostrarUsuarioDTO()
                    {
                        Id = usuarioVM.Id,
                        Nombre = usuarioVM.Nombre,
                        Apellido = usuarioVM.Apellido,
                        Email = usuarioVM.Email,
                        Contrasenia = usuarioVM.Contrasenia,
                        Rol = usuarioVM.Rol,
                        Estado = usuarioVM.Estado
                    };

                    AuditoriaDTO auditoriaDTO = new AuditoriaDTO()
                    {
                        Accion = "Usuario editado",
                        Fecha = DateTime.Now,
                        IdEmpleado = (int)HttpContext.Session.GetInt32("LogueadoId")
                    };

                    CUEditarUsuaro.Ejecutar(usuarioDTO);
                    CUAltaAuditoria.Ejecutar(auditoriaDTO);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.msg = "Error en los datos";

                }
            }
            catch (UsuarioException ex)
            {
                ViewBag.msg = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Error en los datos";
            }
            return View();

        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            MostrarUsuarioViewModel usuarioVM = null;
            try
            {
                int? LogueadoId = HttpContext.Session.GetInt32("LogueadoId");

                if (HttpContext.Session.GetString("LogueadoRol") != "Administrador")
                {
                    return RedirectToAction("NoAutorizado", "Auth");
                }

                if (id <= 0)
                {
                    throw new UsuarioException("Id incorrecto");
                }

                MostrarUsuarioDTO usuarioDTO = CUBuscarUsuario.Ejecutar(id);
                usuarioVM = new MostrarUsuarioViewModel
                {
                    Id = usuarioDTO.Id,
                    Nombre = usuarioDTO.Nombre,
                    Apellido = usuarioDTO.Apellido,
                    Email = usuarioDTO.Email,
                    Rol = usuarioDTO.Rol,
                    Estado = usuarioDTO.Estado
                };
            }
            catch (UsuarioException ex)
            {
                ViewBag.msg = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Datos incorrectos";
            }

            return View(usuarioVM);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MostrarUsuarioViewModel usuarioVM)
        {
            try
            {
                int? LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
                AuditoriaDTO auditoriaDTO = new AuditoriaDTO()
                {
                    Accion = "Usuario dado de baja",
                    Fecha = DateTime.Now,
                    IdEmpleado = (int)HttpContext.Session.GetInt32("LogueadoId")
                };

                CUBorrarUsuario.Ejecutar(id);
                CUAltaAuditoria.Ejecutar(auditoriaDTO);

                return RedirectToAction(nameof(Index));
            }
            catch (UsuarioException ex)
            {
                ViewBag.msg = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Error en los datos";
            }
            return View();
        }
    }
}
