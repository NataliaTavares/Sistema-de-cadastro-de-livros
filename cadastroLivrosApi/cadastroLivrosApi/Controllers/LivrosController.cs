using cadastroLivrosApi.Models;
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
    public class LivrosController : ControllerBase
    {
        private readonly ILivrosService manager;

        public LivrosController(ILivrosService manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Retorna todos os livros.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LivroView>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await manager.GetLivrosAsync());
        }

        /// <summary>
        /// Retorna um livro consultado via ID
        /// </summary>
        /// <param name="id" example="123">Id do livro</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LivroView), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await manager.GetLivroAsync(id));
        }


        /// <summary>
        /// Insere um novo livro.
        /// </summary>
        /// <param name="livro"></param>
        [HttpPost]
        [ProducesResponseType(typeof(LivroView), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoLivro livro)
        {
            var livroInserido = await manager.InsertLivroAsync(livro);
            return CreatedAtAction(nameof(Get), new { id = livroInserido.Id }, livroInserido);
        }


        /// <summary>
        /// Altera um livro
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(LivroView), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(AlteraLivro livro)
        {
            var livroAtualizado = await manager.UpdateLivroAsync(livro);
            if (livroAtualizado == null)
            {
                return NotFound();
            }
            return Ok(livroAtualizado);
        }



        /// <summary>
        /// Exclui um livro.
        /// </summary>
        /// <param name="id" example="123">Id do livro</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await manager.DeleteLivroAsync(id);
            return NoContent();



        }
    }
}
