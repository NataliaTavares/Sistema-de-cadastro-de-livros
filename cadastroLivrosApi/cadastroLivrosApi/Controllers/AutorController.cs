using cadastroLivrosApi.Models;
using cadastroLivrosApi.Models.ModelView.Autores;
using cadastroLivrosApi.Models.ModelView.Erro;
using cadastroLivrosApi.Models.ModelView.Livro;
using cadastroLivrosApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastroLivrosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IAutoresService manager;

        public AutoresController(IAutoresService manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Retorna todos os autores.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AutoresView>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await manager.GetAutoresAsync());
        }

        /// <summary>
        /// Retorna um autor consultado via ID
        /// </summary>
        /// <param name="id" example="123">Id do autor</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AutoresView), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await manager.GetAutorAsync(id));
        }


        /// <summary>
        /// Insere um novo autor.
        /// </summary>
        /// <param name="autor"></param>
        [HttpPost]
        [ProducesResponseType(typeof(AutoresView), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoAutor autor)
        {
            var autorInserido = await manager.InsertAutorAsync(autor);
            return CreatedAtAction(nameof(Get), new { id = autorInserido.Id }, autorInserido);
        }


        /// <summary>
        /// Exclui um autor.
        /// </summary>
        /// <param name="id" example="123">Id do médico</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await manager.DeleteAutorAsync(id);
            return NoContent();

        }


        /// <summary>
        /// Altera um autor
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(AutoresView), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(AlteraAutor autor)
        {
            var autorAtualizado = await manager.UpdateAutorAsync(autor);
            if (autorAtualizado == null)
            {
                return NotFound();
            }
            return Ok(autorAtualizado);
        }

    }
}
