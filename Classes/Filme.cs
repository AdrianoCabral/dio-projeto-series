using Dio.Series;
namespace Dio.Series.Classes
{
    public class Filme : EntidadeBase
    {
        // Atributos
        private string diretor{get;set;}
        
        private int duracao_minutos{get;set;}
        private int indicacoes_oscar{get;set;}
        // Métodos
		public Filme(int id, Genero genero, string titulo, string descricao, int ano, string diretor, int duracao_minutos, int indicacoes_oscar) : base(id, genero, titulo, descricao,ano)
		{
            this.diretor = diretor;
            this.duracao_minutos = duracao_minutos;
            this.indicacoes_oscar = indicacoes_oscar;
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
            retorno += "Diretor: " + this.diretor + Environment.NewLine;
            retorno += "Duração: " + this.duracao_minutos + Environment.NewLine;
            retorno += "Número de Indicações ao Oscar: " + this.indicacoes_oscar;
			return retorno;
		}
    }
}