using System;
using CRUD.Series.Interfaces;
using System.Collections.Generic;

namespace CRUD.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public List<Serie> Lista()
        {
            return this.listaSerie;
        }
        public Serie RetornaPorId(int id)
        {
            return this.listaSerie[id];
        }
        public void Insere(Serie entidade)
        {
            this.listaSerie.Add(entidade);
        }
        public void Excluir(int id)
        {
            this.listaSerie[id].Excluir();
        }
        public void Atualizar(int id, Serie entidade)
        {
            this.listaSerie[id] = entidade;
        }
        public int ProximoId()
        {
            return this.listaSerie.Count;
        }
    }
}