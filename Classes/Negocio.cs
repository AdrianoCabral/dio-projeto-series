using Dio.Series.Interfaces;

namespace Dio.Series.Classes
{
    public class Negocio{
        private IRepositorio<Serie> seriesRepositorio;
        private IRepositorio<Filme> filmesRepositorio;

        public Negocio(){
            this.seriesRepositorio = new SerieRepositorio();
            this.filmesRepositorio = new FilmeRepositorio();
        }

        public void atualizaSerie(int id, Serie serie){
            this.seriesRepositorio.Atualiza(id, serie);
        }
        public void excluirSerie(int id){
            this.seriesRepositorio.Exclui(id);
        }

        public void insereSerie(Serie serie){
            this.seriesRepositorio.Insere(serie);
        }

        public int proximoIdSerie(){
            return this.seriesRepositorio.ProximoId();
        }

        public Serie getSerie(int id){
            return this.seriesRepositorio.RetornaPorId(id);
        }

        public List<Serie> getAllSeries(){
            return this.seriesRepositorio.Lista();
        }

        public void atualizaFilme(int id, Filme filme){
            this.filmesRepositorio.Atualiza(id, filme);
        }
        public void excluirFilme(int id){
            this.filmesRepositorio.Exclui(id);
        }

        public void insereFilme(Filme filme){
            this.filmesRepositorio.Insere(filme);
        }

        public int proximoIdFilme(){
            return this.filmesRepositorio.ProximoId();
        }

        public Filme getFilme(int id){
            return this.filmesRepositorio.RetornaPorId(id);
        }

        public List<Filme> getAllFilmes(){
            return this.filmesRepositorio.Lista();
        }
    }
}