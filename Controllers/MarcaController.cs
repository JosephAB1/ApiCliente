using ApiCliente.Dto;
using ApiCliente.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiCliente.Controllers
{
    [Route("/Api/Marca")]
    [ApiController]
    public class MarcaController : ControllerBase
    {


        private readonly IMarcaRepository marcaRepository;

        public MarcaController(
            
            IMarcaRepository marcaRepository)
        {
            
            this.marcaRepository = marcaRepository;
        }
        /*--------------------Marca--------------------*/

        [Route("/GetMarca")]
        [HttpGet]
        public async Task<ActionResult<ICollection<MarcaDto>>> GetMarca()
        {
            return Ok(await marcaRepository.GetMarca());
        }

        [Route("/GetMarcaById/{id}")]
        [HttpGet]
        public async Task<MarcaDto> GetMarcaById(int id)
        {
            return await marcaRepository.GetMarcayById(id);
        }

        [Route("/CreateMarca")]
        [HttpPost]
        public async Task<MarcaDto> CreateMarca(MarcaDto marca)
        {
            return await marcaRepository.CreateMarca(marca);
        }

        [Route("/UpdateMarca")]
        [HttpPut]
        public async Task<MarcaDto> UpdateMarca(MarcaDto marca)
        {
            return await marcaRepository.UpdateMarca(marca);
        }

        [Route("/DeleteMarca/{id}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteMarca(int id)
        {
            return Ok(await marcaRepository.DeleteMarca(id));
        }
    }
}
