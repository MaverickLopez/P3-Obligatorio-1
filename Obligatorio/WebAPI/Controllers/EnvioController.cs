using Compartido.DTOs.EnvioDTOs;
using LogicaAplicacion.InterfaceCasosUso.EnvioCU;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {

        private IMostrarEnvio CUMostrarEnvio { get; set; }
        private IAltaEnvioComun CUAltaEnvioComun { get; set; }
        private IAltaEnvioUrgente CUAltaEnvioUrgente { get; set; }
        private IBuscarEnvio CUBuscarEnvio { get; set; }
        private IBuscarEnvioNumeroTracking CUBuscarEnvioNumeroTracking { get; set; }
        public EnvioController(IMostrarEnvio cUMostrarEnvio,
            IAltaEnvioComun cUAltaEnvioComun,
            IAltaEnvioUrgente cUAltaEnvioUrgente,
            IBuscarEnvio cUBuscarEnvio,
            IBuscarEnvioNumeroTracking cUBuscarEnvioNumeroTracking)
        {
            CUMostrarEnvio = cUMostrarEnvio;
            CUAltaEnvioComun = cUAltaEnvioComun;
            CUAltaEnvioUrgente = cUAltaEnvioUrgente;
            CUBuscarEnvio = cUBuscarEnvio;
            CUBuscarEnvioNumeroTracking = cUBuscarEnvioNumeroTracking;
        }




        // GET: api/<EnvioController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<EnvioEnteroDTO> listaEnviosDTO = CUMostrarEnvio.Ejecutar();
                if (listaEnviosDTO != null)
                {
                    return Ok(listaEnviosDTO);
                }
                else
                {
                    return NotFound("No existen envios");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // GET api/<EnvioController>/5
        [HttpGet("{numeroTracking}")]
        public IActionResult Get(string numeroTracking)
        {
            try
            {
                if (numeroTracking != null)
                {
                    EnvioEnteroDTO envioDTO = CUBuscarEnvioNumeroTracking.Ejecutar(numeroTracking);
                    return Ok(envioDTO);
                }
                else
                {
                    return BadRequest("El Numero de tracking recibido no es valido");
                }
            }
            catch (EnvioException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }


        }

        // POST api/<EnvioController>
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            try
            {





                return Ok();
            }
            catch (EnvioException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        // PUT api/<EnvioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {


        }

        // DELETE api/<EnvioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {


        }
    }
}
