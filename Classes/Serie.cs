using Dio.Series;
namespace Dio.Series.Classes
{
    public class Serie : EntidadeBase
    {
        // Atributos
        private int num_episodios {get;set;}
        private int num_temporadas{get;set;}
        
        private string showrunner{get;set;}
        // Métodos
		public Serie(int id, Genero genero, string titulo, string descricao, int ano, int num_episodios, int num_temporadas, string showrunner) : base(id, genero, titulo, descricao,ano)
		{
            this.num_episodios = num_episodios;
            this.num_temporadas = num_temporadas;
            this.showrunner = showrunner;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido + Environment.NewLine;
            retorno += "Número de Episódios: " + this.num_episodios + Environment.NewLine;
            retorno += "Numero de Temporadas: " + this.num_temporadas + Environment.NewLine;
            retorno += "Showrunner: " + this.showrunner;
			return retorno;
		}
    }
}