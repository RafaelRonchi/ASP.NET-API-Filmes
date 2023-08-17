namespace API_Filmes.Models
{
    public class FilmeModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Diretor { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Sinopse { get; set;} = string.Empty;
        public int AnoLancamento { get; set; } = 0;
 
    }
}
