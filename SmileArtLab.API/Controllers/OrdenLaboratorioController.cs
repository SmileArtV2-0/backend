
namespace SmileArtLab.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenLaboratorioController(IOrdenLaboratorioService _ordenLaboratorioService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrden(OrdenLaboratorio orden)
        {
            await _ordenLaboratorioService.CreateOrden(orden);
            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerOrden(Guid id)
        {
            var orden = await _ordenLaboratorioService.ObtenerOrden(id);
            return Ok(orden);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerOrdenes()
        {
            var ordenes = await _ordenLaboratorioService.ObtenerOrdenes();
            return Ok(ordenes);
        }

        [HttpGet("detalle/{id}")]
        public async Task<IActionResult> ObtenerOrdenesDetalle(Guid id)
        {
            var orden = await _ordenLaboratorioService.obtenerDetalle(id);
            return Ok(orden);
        }

        [HttpPut("fechaPrueba/{idOrden}")]
        public async Task<IActionResult> AgregarFechaPrueba(Guid idOrden, [FromBody] DateTime fechaPrueba)
        {

            await _ordenLaboratorioService.AgregarFechaPrueba(idOrden, fechaPrueba);
            return Created();
        }
        [HttpPut("fechaFactura/{idOrden}")]
        public async Task<IActionResult> AgregarFechaFactura(Guid idOrden, [FromBody] FechaFacturaRequest request)
        {
            await _ordenLaboratorioService.AgregarFechaFactura(idOrden, request.FechaFactura, request.NumeroFactura);
            return Ok();
        }

        public class FechaFacturaRequest
        {
            public DateTime FechaFactura { get; set; }
            public int NumeroFactura { get; set; }
        }

        [HttpPut("detalle/{idOrden}")]
        public async Task<IActionResult> UpdateOrdenDetalle(Guid idOrden, [FromBody] IEnumerable<OrdenLaboratorioDetalle> detalles)
        {
            await _ordenLaboratorioService.UpdateOrdenDetalle(idOrden, detalles);
            return Created();
        }

        [HttpPut("estado/{idOrden}/{estado}")]
        public async Task<IActionResult> CambiarEstadoOrden(Guid idOrden, string estado)
        {
            await _ordenLaboratorioService.CambiarEstadoOrden(idOrden, estado);
            return Created();
        }



        [HttpGet("numeroOrdenTrabajo")]
        public async Task<IActionResult> ObtenerNumeroOrdenTrabajo()
        {
            var orden = await _ordenLaboratorioService.ObtenerNumeroOrdenTrabajo();
            return Ok(orden);
        }
    }
}
