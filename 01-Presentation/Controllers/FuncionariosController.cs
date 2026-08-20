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

        /// <summary>
        /// Criação de um novo funcionário.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(FuncionarioInputDto dto)
        {
            var criado = await _service.CreateAsync(dto);
            return StatusCode(201, criado);
        }

        /// <summary>
        /// Lista de todos os funcionários cadastrados.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var funcionarios = await _service.GetAllAsync();
            return Ok(funcionarios);
        }

        /// <summary>
        /// Busca um funcionário específico pelo Id.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var funcionario = await _service.GetByIdAsync(id);
                return Ok(funcionario);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Atualiza os dados de um funcionário existente.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, FuncionarioInputDto dto)
        {
            try
            {
                await _service.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Remove um funcionário existente.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}