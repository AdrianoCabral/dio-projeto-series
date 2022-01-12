using Dio.Series;
namespace Dio.Series.Classes
{
    public class Serie : EntidadeBase
    {
        // Atributos
        private int num_episodios {get;set;}
        private int num_temporadas{get;set;}
        // Métodos
		public Serie(int id, Genero genero, string titulo, string descricao, int ano, int num_episodios, int num_temporadas) : base(id, genero, titulo, descricao,ano)
		{
            this.num_episodios = num_episodios;
            this.num_temporadas = num_temporadas;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}
    }
}