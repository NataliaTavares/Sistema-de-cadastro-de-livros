using cadastroLivrosApi.Models;
using cadastroLivrosApi.Models.ModelView.Autores;
using cadastroLivrosApi.Models.ModelView.Erro;
using cadastroLivrosApi.Models.ModelView.Generos;
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
    public class GenerosController : ControllerBase
    {
        private readonly IGenerosService manager;

        public GenerosController(IGenerosService manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Retorna todos os generos.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GeneroView>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await manager.GetGenerosAsync());
        }

        /// <summary>
        /// Retorna um genero consultado via ID
        /// </summary>
        /// <param name="id" example="123">Id do genero</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GeneroView), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await manager.GetGeneroAsync(id));
        }


        /// <summary>
        /// Insere um novo genero.
        /// </summary>
        /// <param name="genero"></param>
        [HttpPost]
        [ProducesResponseType(typeof(GeneroView), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoGenero genero)
        {
            var generoInserido = await manager.InsertGeneroAsync(genero);
            return CreatedAtAction(nameof(Get), new { id = generoInserido.Id }, generoInserido);
        }


        /// <summary>
        /// Exclui um genero.
        /// </summary>
        /// <param name="id" example="123">Id do médico</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await manager.DeleteGeneroAsync(id);
            return NoContent();

        }


        /// <summary>
        /// Altera um genero
        /// </summary>
        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(GeneroView), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(AlteraGenero genero)
        {
            var generoAtualizado = await manager.UpdateGeneroAsync(genero);
            if (generoAtualizado == null)
            {
                return NotFound();
            }
            return Ok(generoAtualizado);
        }

    }
}
