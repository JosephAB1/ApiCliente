using ApiCliente.Dto;
using ApiCliente.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiCliente.Controllers
{

    [Route("/Api/Flota")]
    [ApiController]
    public class FlotaController : ControllerBase
    {

        private readonly IFlotaRepository flotaRepository;

        public FlotaController(
            
            IFlotaRepository flotaRepository)

        {
            
            this.flotaRepository = flotaRepository;

        }

        /*--------------------Flota--------------------*/

        [Route("/GetFlota")]
        [HttpGet]
        public async Task<ActionResult<ICollection<FlotaDto>>> GetFlota()
        {
            return Ok(await flotaRepository.GetFlota());
        }


        [Route("/CreateFlota")]
        [HttpPost]
        public async Task<FlotaDto> CreateFlota(FlotaDto flota)
        {
            return await flotaRepository.CreateFlota(flota);
        }

        [Route("/UpdateFlota")]
        [HttpPut]
        public async Task<FlotaDto> UpdateFlota(FlotaDto flota)
        {
            return await flotaRepository.UpdateFlota(flota);
        }

        [Route("/DeleteFlota/{id}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteFlota(int id)
        {
            return Ok(await flotaRepository.DeleteFlota(id));
        }

    }
}
