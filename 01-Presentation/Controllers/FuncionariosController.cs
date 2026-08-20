using _02_Application.DTOs;
using _02_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _01_Presentation.Controllers
{
    [ApiController]
    [Route("api/funcionarios")]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioService _service;

        public FuncionariosController(IFuncionarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(FuncionarioInputDto dto)
        {
            var criado = await _service.CreateAsync(dto);
            return StatusCode(201, criado);
        }
    }
}
