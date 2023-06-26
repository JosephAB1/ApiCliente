using ApiCliente.Dto;
using ApiCliente.Entity;
using ApiCliente.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiCliente.Controllers
{
    [Route("/Api/Cliente")]
    [ApiController]
    public class ClienteController:ControllerBase
    {

        private readonly IClienteRepository clienteRepository;
        
        
        public ClienteController(
            IClienteRepository clienteRepository
            )
            
        {
            this.clienteRepository = clienteRepository;
            
            
        }


        /*----------------------Clientes--------------------*/
        [Route("/GetClientes")]
        [HttpGet]
        public async Task<ActionResult<ICollection<ClienteDto>>> GetCliente()
        {
            return Ok(await clienteRepository.GetCliente());
        }


        [Route("/CreateCliente")]
        [HttpPost]
        public async Task<ClienteDto> CreateCliente(ClienteDto cliente)
        {
            return await clienteRepository.CreateCliente(cliente);
        }

        [Route("/UpdateCliente")]
        [HttpPut]
        public async Task<ClienteDto> UpdateCliente(ClienteDto cliente)
        {
            return await clienteRepository.UpdateCliente(cliente);
        }

        [Route("/DeleteCliente/{id}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCliente(int id)
        {
            return Ok(await clienteRepository.DeleteCliente(id));
        }


        
       
    }
}
