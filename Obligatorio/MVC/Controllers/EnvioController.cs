using Compartido.DTOs.AgenciaDTOs;
using Compartido.DTOs.ComentarioDTOs;
using Compartido.DTOs.EnvioDTOs;
using LogicaAplicacion.InterfaceCasosUso.AgenciaCU;
using LogicaAplicacion.InterfaceCasosUso.ComentarioCU;
using LogicaAplicacion.InterfaceCasosUso.EnvioCU;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Comentario;
using MVC.Models.Envio;

namespace MVC.Controllers
{
    public class EnvioController : Controller
    {
        private IAltaEnvioComun CUAltaEnvioComun { get; set; }
        private IAltaEnvioUrgente CUAltaEnvioUrgente { get; set; }
        private IMostrarEnvio CUMostrarEnvio { get; set; }
        private IMostrarAgencia CUMostrarAgencia { get; set; }
        private IBuscarEnvio CUBuscarEnvio { get; set; }
        private IFinalizarEnvio CUFinalizarEnvio { get; set; }
        private IAltaComentario CUAltaComentario { get; set; }

        public EnvioController(IAltaEnvioComun cUAltaEnvio,
            IAltaEnvioUrgente cUltaEnvioUrgente,
            IMostrarEnvio cUMostrarEnvio,
            IMostrarAgencia cUMostrarAgencia,
            IBuscarEnvio cUBuscarEnvio,
            IFinalizarEnvio cUFinalizarEnvio,
            IAltaComentario cUAltaComentario)
        {
            CUAltaEnvioComun = cUAltaEnvio;
            CUAltaEnvioUrgente = cUltaEnvioUrgente;
            CUMostrarEnvio = cUMostrarEnvio;
            CUMostrarAgencia = cUMostrarAgencia;
            CUBuscarEnvio = cUBuscarEnvio;
            CUFinalizarEnvio = cUFinalizarEnvio;
            CUAltaComentario = cUAltaComentario;
        }

        // GET: EnvioController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                List<EnvioEnteroDTO> mostrarEnviosDTO = CUMostrarEnvio.Ejecutar();
                List<EnvioEnteroViewModel> mostrarEnviosVM = new List<EnvioEnteroViewModel>();

                foreach (EnvioEnteroDTO m in mostrarEnviosDTO)
                {
                    EnvioEnteroViewModel mostrarEnvioVM = new EnvioEnteroViewModel()
                    {
                        Id = m.Id,
                        NumeroTracking = m.NumeroTracking,
                        EmpleadoId = m.EmpleadoId,
                        ClienteId = m.ClienteId,
                        Peso = m.Peso,
                        Estado = m.Estado
                    };

                    mostrarEnviosVM.Add(mostrarEnvioVM);
                }

                return View(mostrarEnviosVM);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        // GET: EnvioController/Create
        public ActionResult CreateComun()
        {
            AltaEnvioComunViewModel envioVM = new AltaEnvioComunViewModel();
            try
            {
                int? LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
                List<AgenciaEnteraDTO> datosAgencias = CUMostrarAgencia.Ejecutar();

                envioVM.Agencias = datosAgencias.Select(
                    dtoAgencia => new Models.Agencia.MostrarAgenciaViewModel()
                    {
                        Id = dtoAgencia.Id,
                        Nombre = dtoAgencia.Nombre
                    });
            }
            catch (EnvioException ex)
            {
                ViewBag.msg = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Error en los datos";
            }

            return View(envioVM);
        }

        // POST: EnvioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComun(AltaEnvioComunViewModel envioVM)
        {
            try
            {
                int? LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
                if (ModelState.IsValid)
                {
                    AltaEnvioComunDTO envioDTO = new AltaEnvioComunDTO()
                    {
                        Email = envioVM.Email,
                        EmpleadoId = (int)LogueadoId,
                        Peso = envioVM.Peso,
                        AgenciaId = envioVM.AgenciaId
                    };

                    int EnvioId = CUAltaEnvioComun.Ejecutar(envioDTO);
                    ComentarioDTO comentarioDTO = new ComentarioDTO()
                    {
                        EnvioId = EnvioId,
                        Fecha = DateTime.Now,
                        EmpleadoId = (int)LogueadoId,
                        TextoComentario = "Ingresado en agencia de origen"
                    };
                    CUAltaComentario.Ejecutar(comentarioDTO);

                    return RedirectToAction(nameof(Index));
                }

            }
            catch (EnvioException ex)
            {
                ViewBag.msg = ex.Message;
            }
            catch (UsuarioException ex)
            {
                ViewBag.msg = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Error en los datos";
            }
            return View(envioVM);
        }


        // GET: EnvioController/Create
        public ActionResult CreateUrgente()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        // POST: EnvioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUrgente(AltaEnvioUrgenteViewModel envioVM)
        {
            try
            {
                int? LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
                if (ModelState.IsValid)
                {
                    AltaEnvioUrgenteDTO envioDTO = new AltaEnvioUrgenteDTO()
                    {
                        Email = envioVM.Email,
                        EmpleadoId = (int)LogueadoId,
                        Peso = envioVM.Peso,
                        DireccionPostal = envioVM.DireccionPostal
                    };

                    int EnvioId = CUAltaEnvioUrgente.Ejecutar(envioDTO);
                    ComentarioDTO comentarioDTO = new ComentarioDTO()
                    {
                        EnvioId = EnvioId,
                        Fecha = DateTime.Now,
                        EmpleadoId = (int)LogueadoId,
                        TextoComentario = "Ingresado en agencia de origen"
                    };
                    CUAltaComentario.Ejecutar(comentarioDTO);

                    return RedirectToAction(nameof(Index));
                }

            }
            catch (EnvioException ex)
            {
                ViewBag.msg = ex.Message;
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

        // GET: EnvioController/Delete/5
        public ActionResult Delete(int id)
        {
            EnvioEnteroViewModel envioVM = null;
            try
            {
                int? LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
                if (id <= 0)
                {
                    throw new EnvioException("Id incorrecto");
                }
                EnvioEnteroDTO envioDTO = CUBuscarEnvio.Ejecutar(id);
                envioVM = new EnvioEnteroViewModel
                {
                    Id = envioDTO.Id,
                    NumeroTracking = envioDTO.NumeroTracking,
                    EmpleadoId = envioDTO.EmpleadoId,
                    ClienteId = envioDTO.ClienteId,
                    Peso = envioDTO.Peso,
                    Estado = envioDTO.Estado
                };
            }
            catch (EnvioException ex)
            {
                ViewBag.msg = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Datos incorrectos";
            }
            return View(envioVM);
        }

        // POST: EnvioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EnvioEnteroViewModel envioVM)
        {
            try
            {
                int? LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
                ComentarioDTO comentarioDTO = new ComentarioDTO()
                {
                    EnvioId = envioVM.Id,
                    Fecha = DateTime.Now,
                    EmpleadoId = (int)LogueadoId,
                    TextoComentario = "Finalizado"
                };
                CUAltaComentario.Ejecutar(comentarioDTO);

                CUFinalizarEnvio.Ejecutar(id);

                return RedirectToAction(nameof(Index));
            }
            catch (EnvioException ex)
            {
                ViewBag.msg = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Error en los datos";
            }
            return View();
        }


        public IActionResult AgregarComentario(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                ViewBag.EnvioId = id;
                return View();
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        [HttpPost]
        public IActionResult AgregarComentario(ComentarioViewModel comentarioVM)
        {
            try
            {
                int? LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
                if (ModelState.IsValid)
                {
                    ComentarioDTO comentarioDTO = new ComentarioDTO()
                    {
                        EnvioId = comentarioVM.EnvioId,
                        Fecha = DateTime.Now,
                        EmpleadoId = (int)LogueadoId,
                        TextoComentario = comentarioVM.TextoComentario
                    };

                    CUAltaComentario.Ejecutar(comentarioDTO);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (ComentarioException ex)
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
