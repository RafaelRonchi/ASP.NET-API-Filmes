using API_Filmes.Data;
using API_Filmes.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API_Filmes.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly DataContext _dataContext;

        public FilmeService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<FilmeModel>> GetAllFilmes()
        {
            var filmes = await _dataContext.Filmes.ToListAsync();

            return filmes;
        }

        public async Task<FilmeModel> GetFilmeById(int id)
        {
            var filme = await _dataContext.Filmes.FindAsync(id);
            if (filme == null) return null;
            return filme;
        }

        public async Task<List<FilmeModel>> AddFilme(FilmeModel filme)
        {
            _dataContext.Filmes.Add(filme);
            await _dataContext.SaveChangesAsync();

            return await GetAllFilmes();
        }

        public async  Task<List<FilmeModel>> DeleteFilme(int id)
        {
            var filme = await _dataContext.Filmes.FindAsync(id);
            if (filme == null) return null;

            _dataContext.Filmes.Remove(filme);
            await _dataContext.SaveChangesAsync();
            return await GetAllFilmes();
        }


        public async Task<List<FilmeModel>> UpdateFilme(int id, FilmeModel request)
        {
            var filme = await _dataContext.Filmes.FindAsync(id);

            if (filme == null) return null;

            filme.Titulo = request.Titulo;
            filme.Sinopse = request.Sinopse;
            filme.AnoLancamento = request.AnoLancamento;
            filme.Diretor = request.Diretor;

            await _dataContext.SaveChangesAsync();

            return await GetAllFilmes();
        }

        public async Task<List<FilmeModel>> SelecionaGenero(string genero)
        {
            var filme = await _dataContext.Filmes.Where(f => f.Genero == genero).ToListAsync();
            if (filme == null) return null;
            return filme;
        }

        public async Task<List<FilmeModel>> SelecionaDiretor(string diretor)
        {
            var filme = await _dataContext.Filmes.Where(f => f.Diretor == diretor).ToListAsync();
            if (filme == null) return null;
            return filme;
        }

        public async Task<List<FilmeModel>> SelecionaAno(int ano)
        {
            var filme = await _dataContext.Filmes.Where(f => f.AnoLancamento == ano).ToListAsync();
            if (filme == null) return null;
            return filme;
        }
    }
}
