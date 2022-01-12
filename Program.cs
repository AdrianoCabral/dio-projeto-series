using Dio.Series.Classes;
using Dio.Series;

namespace Dio.Series
{
    class Program
    {
        static Negocio negocio = new Negocio();
        static Boolean isSerie = true;
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;
                    case "6":
                        isSerie = false;
                        break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
            try
            {
            	Console.Write("Digite o id d{0} {1}: ", isSerie? "a": "o", isSerie ? "Série" : "Filme");
			    int indiceSerie = int.Parse(Console.ReadLine());
                negocio.excluirSerie(indiceSerie);
            }
            catch (Exception e)
            {
                if(e is FormatException){
                    Console.WriteLine("ERRO! O valor digitado é inválido.");
                }else{
                    Console.WriteLine("ERRO! Série não encontrada");
                }
            }
			
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id d{0} {1}: ", isSerie? "a": "o", isSerie ? "Série" : "Filme");
			int indiceSerie = int.Parse(Console.ReadLine());
            try
            {
                var serie = negocio.getSerie(indiceSerie);
                Console.WriteLine(serie);
            }
            catch (Exception e)
            {
                if(e is FormatException){
                    Console.WriteLine("ERRO! O valor digitado é inválido.");
                }else{
                    Console.WriteLine("ERRO! Série não encontrada");
                }
            }
				
		}

        private static void AtualizarSerie()
		{
            try
            {
                Console.Write("Digite o id d{0} {1}: ", isSerie? "a": "o", isSerie ? "Série" : "Filme");
                int indiceSerie = int.Parse(Console.ReadLine());

                // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
                // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.Write("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o Título d{0} {1}: ", isSerie? "a": "o", isSerie ? "Série" : "Filme");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o Ano de Lançamento d{0} {1}: ", isSerie? "a": "o", isSerie ? "Série" : "Filme");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a Descrição d{0} {1}: ", isSerie? "a": "o", isSerie ? "Série" : "Filme");
                string entradaDescricao = Console.ReadLine();

                if(isSerie){
                    Console.Write("Digite o numero de episódios: ");
                    int entrada_num_episodios = int.Parse(Console.ReadLine());

                    Console.Write("Digite o numero de temporadas: ");
                    int entrada_num_temporadas = int.Parse(Console.ReadLine());
                    Serie atualizaSerie = new Serie(id: indiceSerie,
                            genero: (Genero)entradaGenero,
                            titulo: entradaTitulo,
                            descricao: entradaDescricao,
                            ano: entradaAno,
                            num_episodios: entrada_num_episodios,
                            num_temporadas: entrada_num_temporadas
                            );
                    negocio.atualizaSerie(indiceSerie, atualizaSerie);
                }else{

                }
            }
            catch (Exception e)
            {
                if(e is FormatException){
                    Console.WriteLine("ERRO! O valor digitado é inválido.");
                }else{
                    Console.WriteLine("ERRO! Série não encontrada");
                }

            }
			
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar {0}", isSerie? "séries":"filmes");

			var lista = negocio.getAllSeries();

			if (lista.Count == 0)
			{
				Console.WriteLine("{0}", isSerie? "Nenhuma série registrada": "Nenhum filme registrado");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                if(!excluido){
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
				
			}
		}

        private static void InserirSerie()
		{
            try
            {
                Console.WriteLine("Inserir nov{0} {1}: ", isSerie? "a": "o", isSerie ? "Série" : "Filme");

                // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
                // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.Write("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o Título d{0} {1}: ", isSerie? "a": "o", isSerie ? "Série" : "Filme");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o Ano de Lançamento d{0} {1}: ", isSerie? "a": "o", isSerie ? "Série" : "Filme");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write("Digite a Descrição d{0} {1}: ", isSerie? "a": "o", isSerie ? "Série" : "Filme");
                string entradaDescricao = Console.ReadLine();

                if(isSerie){
                    Console.Write("Digite o numero de episódios: ");
                    int entrada_num_episodios = int.Parse(Console.ReadLine());

                    Console.Write("Digite o numero de temporadas: ");
                    int entrada_num_temporadas = int.Parse(Console.ReadLine());

                    Serie novaSerie = new Serie(id: negocio.proximoIdSerie(),
                                                genero: (Genero)entradaGenero,
                                                titulo: entradaTitulo,
                                                descricao: entradaDescricao,
                                                ano: entradaAno,
                                                num_episodios: entrada_num_episodios,
                                                num_temporadas: entrada_num_temporadas
                                                );

                    negocio.insereSerie(novaSerie);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("ERRO! O valor digitado é inválido.");
            }
			
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar {0}", isSerie? "séries":"filmes");
			Console.WriteLine("2- Inserir nov{0} {1}", isSerie? "a":"o", isSerie? "série":"filme");
			Console.WriteLine("3- Atualizar {0}", isSerie? "série":"filme");
			Console.WriteLine("4- Excluir {0}", isSerie? "série":"filme");
			Console.WriteLine("5- Visualizar {0}", isSerie? "série":"filme");
            Console.WriteLine("6- Trocar para o menu de {0}", isSerie? "filmes":"séries");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}