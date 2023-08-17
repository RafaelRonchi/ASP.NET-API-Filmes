using API_Filmes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Filmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmesController (IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FilmeModel>>> GetAllFilems()
        {
            return await _filmeService.GetAllFilmes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FilmeModel>> GetSingleFilme(int id)
        {
            var result = await _filmeService.GetFilmeById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<FilmeModel>>> AddFilme(FilmeModel f)
        {
            var result = await _filmeService.AddFilme(f);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<FilmeModel>>> UpdateFilme(int id, FilmeModel request)
        {
            var result = await _filmeService.UpdateFilme(id, request);
            if (result == null) return null;
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FilmeModel>> delFilme(int id)
        {
            var result = await _filmeService.DeleteFilme(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("genero/{genero}")]
        public async Task<ActionResult<List<FilmeModel>>> GetFilmesGenero(string genero)
        {
            var result = await _filmeService.SelecionaGenero(genero);
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("diretor/{diretor}")]
        public async Task<ActionResult<List<FilmeModel>>> GetFilmesDiretor(string diretor)
        {
            var result = await _filmeService.SelecionaDiretor(diretor);
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("ano/{ano}")]
        public async Task<ActionResult<List<FilmeModel>>> GetFilmesAno(int ano)
        {
            var result = await _filmeService.SelecionaAno(ano);
            if (result is null) return NotFound();
            return Ok(result);
        }
    }
}
