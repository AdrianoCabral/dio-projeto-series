# dio-projeto-series
## Projeto base mostrado no bootcamp: https://github.com/elizarp/dio-dotnet-poo-lab-2

## Minhas alterações:
### Adicionei uma camada de negócio entre a fachada e os repositórios
### Adicionei tratamento de exceções para o programa não parar com erros comuns
### Passei os atributos de Serie para EntidadeBase
### Adicionei novos atributos em Serie
### Criei uma classe Filme também herdando de EntidadeBase, e um FilmesRepositorio implementando IRepositorio
### Modifiquei a fachada para comportar um menu de filmes


Na classe de fachada, no método Listar(), há repetição de código e uma chamada desnecessária dos 2 repositórios sempre, mesmo o não sendo necessário.
Não sei exatamente o que mudar para fazer isso, talvez fazer o getAllSeries/Filmes() retornar uma lista de tipo genérico, mas não sei como fazer isso.
