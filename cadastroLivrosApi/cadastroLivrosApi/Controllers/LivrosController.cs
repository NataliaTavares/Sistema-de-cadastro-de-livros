using cadastroLivrosApi.Models;
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
        private ILivrosService _livrosService;

        public LivrosController(ILivrosService livrosService)
        {
            _livrosService = livrosService;
        }

        [HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
       //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IAsyncEnumerable<Livro>>> GetLivros()
        {
            try
            {
                var livros = await _livrosService.GetLivros();
                return Ok(livros);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter livros");
            }
        }


        [HttpGet ("LivroPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Livro>>> 
            GetLivrosByName([FromQuery] string nome)
        {
            try
            {
                var livros = await _livrosService.GetLivrosByNome(nome);

                if (livros.Count() == 0)
                   return NotFound($"Não exixtem os livros com o critério {nome}");

                return Ok(livros);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }


        [HttpGet("{id:int}", Name = "GetLivro")]

        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            try
            {
                var livro = await _livrosService.GetLivro(id);

                if (livro == null)
                    return NotFound($"Não exixte o livro com o id={id}");

                return Ok(livro);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPost]

        public async Task<ActionResult> Create(Livro livro)
        {
            try
            {
                await _livrosService.CreateLivro(livro);
                return CreatedAtRoute(nameof(GetLivro), new { id = livro.Id }, livro);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPut ("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Livro livro)
        {
            try
            {
                if(livro.Id == id) 
                {
                    await _livrosService.UpdateLivro(livro);
                    return Ok($"Aluno com if{id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados inconcistentes");
                }
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                
                var livro = await _livrosService.GetLivro(id);
                

                if (livro != null)
                {
                    await _livrosService.DeleteLivro(livro);

                    return Ok($"Livro de id:{id} foi excluído com sucesso");
                    //return Ok($"Vamos la");
                }
                else
                {
                    return NotFound($"Livro com id={id} não encontrado");
                }
            }
            catch
            {
                return BadRequest("Request inválido temos uma problema");
            }
        }
    }
}
