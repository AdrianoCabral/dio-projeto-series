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
						Listar();
						break;
					case "2":
						Inserir();
						break;
					case "3":
						Atualizar();
						break;
					case "4":
						Excluir();
						break;
					case "5":
						Visualizar();
						break;
					case "C":
						Console.Clear();
						break;
                    case "6":
                        isSerie = !isSerie;
                        break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void Excluir()
		{
            try
            {
            	Console.Write("Digite o id d{0} {1}: ", isSerie? "a": "o", isSerie ? "Série" : "Filme");
			    int indiceSerie = int.Parse(Console.ReadLine());
                
                if(isSerie){negocio.excluirSerie(indiceSerie);}
                else{negocio.excluirFilme(indiceSerie);}
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

        private static void Visualizar()
		{
			Console.Write("Digite o id d{0} {1}: ", isSerie? "a": "o", isSerie ? "Série" : "Filme");
			int indiceSerie = int.Parse(Console.ReadLine());
            try
            {   
                if(isSerie){var serie = negocio.getSerie(indiceSerie);Console.WriteLine(serie);}
                else{var filme = negocio.getFilme(indiceSerie);Console.WriteLine(filme);}
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

        private static void Atualizar()
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

                    Console.WriteLine("Digite o nome do Showrunner: ");
                    string entrada_showrunner = Console.ReadLine();

                    Serie atualizaSerie = new Serie(id: indiceSerie,
                            genero: (Genero)entradaGenero,
                            titulo: entradaTitulo,
                            descricao: entradaDescricao,
                            ano: entradaAno,
                            num_episodios: entrada_num_episodios,
                            num_temporadas: entrada_num_temporadas,
                            showrunner: entrada_showrunner
                            );
                    negocio.atualizaSerie(indiceSerie, atualizaSerie);
                }else{
                    Console.Write("Digite o nome do diretor: ");
                    string entrada_diretor = Console.ReadLine();

                    Console.Write("Digite a duração do filme em minutos: ");
                    int entrada_duracao_minutos = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o número de indicações ao Oscar: ");
                    int entrada_indicacoes = int.Parse(Console.ReadLine());

                    Filme atualizaFilme = new Filme(id: indiceSerie,
                            genero: (Genero)entradaGenero,
                            titulo: entradaTitulo,
                            descricao: entradaDescricao,
                            ano: entradaAno,
                            diretor: entrada_diretor,
                            duracao_minutos: entrada_duracao_minutos,
                            indicacoes_oscar: entrada_indicacoes
                            );
                    negocio.atualizaFilme(indiceSerie, atualizaFilme);
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
        private static void Listar()
		{
			Console.WriteLine("Listar {0}", isSerie? "séries":"filmes");

            //numa aplicação real isso seria muito ruim, porque estou dando get nos 2 repositórios sem precisar
            //porém n sei um jeito melhor de fazer aqui, por causa do fato de c# ser fortemente tipada não posso simplesmente sobrescrever a lista
			var lista = negocio.getAllSeries();
            var lista2 = negocio.getAllFilmes();

			if ((lista.Count == 0 && isSerie) || (lista2.Count == 0 && !isSerie))
			{
				Console.WriteLine("{0}", isSerie? "Nenhuma série registrada": "Nenhum filme registrado");
				return;
			}
            
            //duplicação de código pelo mesmo motivo que citei acima
            if(isSerie){
                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();
                    if(!excluido){
                        Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                    }
                    
                }
            }else{
                foreach (var filme in lista2)
                {
                    var excluido = filme.retornaExcluido();
                    if(!excluido){
                        Console.WriteLine("#ID {0}: - {1}", filme.retornaId(), filme.retornaTitulo());
                    }
                    
                }
            }


		}

        private static void Inserir()
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

                    Console.WriteLine("Digite o nome do Showrunner: ");
                    string entrada_showrunner = Console.ReadLine();

                    Serie novaSerie = new Serie(id: negocio.proximoIdSerie(),
                                                genero: (Genero)entradaGenero,
                                                titulo: entradaTitulo,
                                                descricao: entradaDescricao,
                                                ano: entradaAno,
                                                num_episodios: entrada_num_episodios,
                                                num_temporadas: entrada_num_temporadas,
                                                showrunner: entrada_showrunner
                                                );

                    negocio.insereSerie(novaSerie);
                }else{
                    Console.Write("Digite o nome do diretor: ");
                    string entrada_diretor = Console.ReadLine();

                    Console.Write("Digite a duração do filme em minutos: ");
                    int entrada_duracao_minutos = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o número de indicações ao Oscar: ");
                    int entrada_indicacoes = int.Parse(Console.ReadLine());

                    Filme filme = new Filme(id: negocio.proximoIdFilme(),
                            genero: (Genero)entradaGenero,
                            titulo: entradaTitulo,
                            descricao: entradaDescricao,
                            ano: entradaAno,
                            diretor: entrada_diretor,
                            duracao_minutos: entrada_duracao_minutos,
                            indicacoes_oscar: entrada_indicacoes
                            );
                    negocio.insereFilme(filme);
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