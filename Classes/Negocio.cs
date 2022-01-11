using Dio.Series.Interfaces;

namespace Dio.Series.Classes
{
    public class Negocio{
        private IRepositorio<Serie> seriesRepositorio;

        public Negocio(){
            this.seriesRepositorio = new SerieRepositorio();
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
    }
}