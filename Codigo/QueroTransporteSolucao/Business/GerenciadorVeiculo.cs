
using Persistence;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Negocio
{
    public class GerenciadorVeiculo : IGerenciadorVeiculo
    {

        private readonly BD_QUERO_TRANSPORTEContext _context;

        public GerenciadorVeiculo(BD_QUERO_TRANSPORTEContext Context)
        {
            this._context = Context;
        }

        /// <summary>
        /// Inseri um veiculo na base de dados
        /// </summary>
        /// <param name="veiculoModel"></param>
        /// <returns></returns>
        public int Inserir(VeiculoModel Veiculo)
        {
            Veiculo _veiculo = new Veiculo();

            Atribuir(Veiculo, _veiculo);


            _context.Add(_veiculo);
            _context.SaveChanges();
            return _veiculo.Id;
        }


        /// <summary>
        /// Altera os dados de um veiculo da base de dados
        /// </summary>
        /// <param name="veiculoModel"></param>
        public void Alterar(VeiculoModel Veiculo)
        {
            Veiculo _veiculo = new Veiculo();

            Atribuir(Veiculo, _veiculo);
            _context.Update(_veiculo);
            _context.SaveChanges();

        }

        /// <summary>
        /// Busca um veiculo na base de dados
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public VeiculoModel Buscar(int Id)
        {
            IEnumerable<VeiculoModel> veiculos = GetQuery().Where(veiculoModel => veiculoModel.Id.Equals(Id));
            return veiculos.ElementAtOrDefault(0);
        }

        /// <summary>
        /// Exclui um veiculo na base de dados
        /// </summary>
        /// <param name="Id"></param>
        public void Excluir(int Id)
        {
            var veiculo = _context.Veiculo.Find(Id);
            _context.Veiculo.Remove(veiculo);
            _context.SaveChanges();
        }



        /// <summary>
        /// Atribui dados de um objeto para outro
        /// </summary>
        /// <param name="Veiculo"></param>
        /// <param name="_veiculo"></param>
        private void Atribuir(VeiculoModel Veiculo, Veiculo _veiculo)
        {
            _veiculo.Id = Veiculo.Id;
            _veiculo.AnoFabricacao = Veiculo.AnoFabricacao;
            _veiculo.AnoModelo = Veiculo.AnoModelo;
            _veiculo.Capacidade = Veiculo.Capacidade;
            _veiculo.Categoria = Veiculo.Categoria;
            _veiculo.Chassi = Veiculo.Chassi;
            _veiculo.Cor = Veiculo.Cor;
            _veiculo.DataEmplacamento = Veiculo.DataEmplacamento;
            _veiculo.Frota = Veiculo.IdFrota;
            _veiculo.Marca = Veiculo.Marca;
            _veiculo.Modelo = Veiculo.Modelo;
            _veiculo.Placa = Veiculo.Placa;
        }


        /// <summary>
        ///  retorna todas as rotas da base de dados
        /// </summary>
        /// <returns></returns>
        private IQueryable<VeiculoModel> GetQuery()
        {
            IQueryable<Veiculo> Veiculo = _context.Veiculo;
            var query = from veiculo in Veiculo
                        select new VeiculoModel
                        {
                            Id = veiculo.Id,
                            AnoFabricacao = veiculo.AnoFabricacao,
                            AnoModelo = veiculo.AnoModelo,
                            Capacidade = veiculo.Capacidade,
                            Categoria = veiculo.Categoria,
                            Chassi = veiculo.Chassi,
                            Cor = veiculo.Cor,
                            IdFrota = (int)veiculo.Frota,
                            DataEmplacamento = veiculo.DataEmplacamento,
                            Marca = veiculo.Marca,
                            Modelo = veiculo.Modelo,
                            Placa = veiculo.Placa
                        };
            return query;
        }


        /// <summary>
        /// Obtem todos os veiculos da base de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<VeiculoModel> ObterTodos()
        {
            return GetQuery();
        }


        /// <summary>
        /// Pesquisa veiculos por modelo
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        public IEnumerable<VeiculoModel> ObterPorModelo(string Modelo)
        {
            IEnumerable<VeiculoModel> veiculos = GetQuery().Where(veiculoModel => veiculoModel.Modelo.StartsWith(Modelo));
            return veiculos;
        }
    }
}