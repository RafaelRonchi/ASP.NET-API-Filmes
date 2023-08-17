using API_Filmes.Models;

namespace API_Filmes.Services
{
    public interface IFilmeService
    {
        Task<List<FilmeModel>> GetAllFilmes();
        Task<FilmeModel> GetFilmeById(int Id);
        Task<List<FilmeModel>> AddFilme(FilmeModel filme);
         Task<List<FilmeModel>> UpdateFilme(int id, FilmeModel request);
         Task<List<FilmeModel>> DeleteFilme(int id);

        Task<List<FilmeModel>> SelecionaGenero(string genero);

        Task<List<FilmeModel>> SelecionaDiretor(string diretor);
        Task<List<FilmeModel>> SelecionaAno(int ano);
    }
}
