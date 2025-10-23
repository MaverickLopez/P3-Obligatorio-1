using Compartido.DTOs.AgenciaDTOs;
using Compartido.DTOs.UsuarioDTOs;
using LogicaAplicacion.InterfaceCasosUso.AgenciaCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Agencia;
using MVC.Models.Usuario;

namespace MVC.Controllers
{
    public class AgenciaController : Controller
    {
        private IAltaAgencia CUAltaAgencia { get; set; }
        private IMostrarAgencia CUMostrarAgencia { get; set; }
        private IBuscarAgencia CUBuscarAgencia { get; set; }
        private IEditarAgencia CUEditarAgencia { get; set; }

        public AgenciaController(IAltaAgencia cUAltaAgencia,
            IMostrarAgencia cUMostrarAgencia,
            IBuscarAgencia cUBuscarAgencia,
            IEditarAgencia cUEditarAgencia)
        {
            CUAltaAgencia = cUAltaAgencia;
            CUMostrarAgencia = cUMostrarAgencia;
            CUBuscarAgencia = cUBuscarAgencia;
            CUEditarAgencia = cUEditarAgencia;
        }



        // GET: AgenciaController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                List<AgenciaEnteraDTO> mostrarAgenciasDTO = CUMostrarAgencia.Ejecutar();
                List<MostrarAgenciaViewModel> mostrarAgenciasVM = new List<MostrarAgenciaViewModel>();

                foreach (AgenciaEnteraDTO a in mostrarAgenciasDTO)
                {
                    MostrarAgenciaViewModel mostrarAgenciaVM = new MostrarAgenciaViewModel()
                    {
                        Id = a.Id,
                        Nombre = a.Nombre,
                        DireccionPostal = a.DireccionPostal,
                        Latitud = a.Latitud,
                        Longitud = a.Longitud
                    };
                    mostrarAgenciasVM.Add(mostrarAgenciaVM);
                }

                return View(mostrarAgenciasVM);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        // GET: AgenciaController/Create
        public ActionResult Create()
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

        // POST: AgenciaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AgenciaViewModel agenciaVM)
        {
            try
            {
                int? LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
                if (ModelState.IsValid)
                {
                    AgenciaDTO agenciaDTO = new AgenciaDTO()
                    {
                        Nombre = agenciaVM.Nombre,
                        DireccionPostal = agenciaVM.DireccionPostal,
                        Latitud = agenciaVM.Latitud,
                        Longitud = agenciaVM.Longitud
                    };

                    CUAltaAgencia.Ejecutar(agenciaDTO);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (AgenciaExcepction ex)
            {
                ViewBag.msg = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Error en los datos";
            }
            return View();
        }

        // GET: AgenciaController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetInt32("LogueadoId") != null)
            {
                MostrarAgenciaViewModel mostrarAgenciaVM = null;
                try
                {
                    if (id <= 0)
                    {
                        throw new AgenciaExcepction("Id incorrecto");
                    }
                    AgenciaEnteraDTO agenciaEnteraDTO = CUBuscarAgencia.Ejecutar(id);
                    mostrarAgenciaVM = new MostrarAgenciaViewModel()
                    {
                        Id = agenciaEnteraDTO.Id,
                        Nombre = agenciaEnteraDTO.Nombre,
                        DireccionPostal = agenciaEnteraDTO.DireccionPostal,
                        Latitud = agenciaEnteraDTO.Latitud,
                        Longitud = agenciaEnteraDTO.Longitud
                    };
                }
                catch (AgenciaExcepction ex)
                {
                    ViewBag.msg = ex.Message;
                }
                return View(mostrarAgenciaVM);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }

        // POST: AgenciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MostrarAgenciaViewModel agenciaVM)
        {
            try
            {
                int? LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
                if (ModelState.IsValid)
                {
                    AgenciaEnteraDTO agenciaDTO = new AgenciaEnteraDTO()
                    {
                        Id = agenciaVM.Id,
                        Nombre = agenciaVM.Nombre,
                        DireccionPostal = agenciaVM.DireccionPostal,
                        Latitud = agenciaVM.Latitud,
                        Longitud = agenciaVM.Longitud
                    };

                    CUEditarAgencia.Ejecutar(agenciaDTO);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.msg = "Error en los datos";
                }
            }
            catch(AgenciaExcepction ex)
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
