
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

        public GerenciadorVeiculo(BD_QUERO_TRANSPORTEContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Inseri um veiculo na base de dados
        /// </summary>
        /// <param name="veiculoModel"></param>
        /// <returns></returns>
        public int Inserir(VeiculoModel veiculoModel)
        {
            Veiculo _veiculo = new Veiculo();

            _veiculo.Id = veiculoModel.Id;
            _veiculo.AnoFabricacao = veiculoModel.AnoFabricacao;
            _veiculo.AnoModelo = veiculoModel.AnoModelo;
            _veiculo.Capacidade = veiculoModel.Capacidade;
            _veiculo.Categoria = veiculoModel.Categoria;
            _veiculo.Chassi = veiculoModel.Chassi;
            _veiculo.Cor = veiculoModel.Cor;
            _veiculo.DataEmplacamento = veiculoModel.DataEmplacamento;
            _veiculo.Frota = veiculoModel.IdFrota;
            _veiculo.Marca = veiculoModel.Marca;
            _veiculo.Modelo = veiculoModel.Modelo;
            _veiculo.Placa = veiculoModel.Placa;


            _context.Add(_veiculo);
            _context.SaveChanges();
            return _veiculo.Id;
        }


        /// <summary>
        /// Altera os dados de um veiculo da base de dados
        /// </summary>
        /// <param name="veiculoModel"></param>
        public void Alterar(VeiculoModel veiculoModel)
        {
            Veiculo _veiculo = new Veiculo();

            Atribuir(veiculoModel, _veiculo);
            _context.Update(_veiculo);
            _context.SaveChanges();

        }

        /// <summary>
        /// Busca um veiculo na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VeiculoModel Buscar(int id)
        {
            IEnumerable<VeiculoModel> veiculos = GetQuery().Where(veiculoModel => veiculoModel.Id.Equals(id));

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
        /// <param name="veiculoModel"></param>
        /// <param name="_veiculo"></param>
        private void Atribuir(VeiculoModel veiculoModel, Veiculo _veiculo)
        {
            _veiculo.Id = veiculoModel.Id;
            _veiculo.AnoFabricacao = veiculoModel.AnoFabricacao;
            _veiculo.AnoModelo = veiculoModel.AnoModelo;
            _veiculo.Capacidade = veiculoModel.Capacidade;
            _veiculo.Categoria = veiculoModel.Categoria;
            _veiculo.Chassi = veiculoModel.Chassi;
            _veiculo.Cor = veiculoModel.Cor;
            _veiculo.DataEmplacamento = veiculoModel.DataEmplacamento;
            _veiculo.Frota = veiculoModel.IdFrota;
            _veiculo.Marca = veiculoModel.Marca;
            _veiculo.Modelo = veiculoModel.Modelo;
            _veiculo.Placa = veiculoModel.Placa;
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
        public IEnumerable<VeiculoModel> ObterPorModelo(string modelo)
        {
            IEnumerable<VeiculoModel> veiculos = GetQuery().Where(veiculoModel => veiculoModel.Modelo.StartsWith(modelo));
            return veiculos;
        }

        public List<FrotaModel> ObterFrotas()
        {
            return GetQueryFrotas().ToList();
        }

        private IQueryable<FrotaModel> GetQueryFrotas()
        {
            IQueryable<Frota> Frota = _context.Frota;
            var query = from frota in Frota
                        select new FrotaModel
                        {
                            Id = frota.Id,
                            Titulo = frota.Titulo
                        };
            return query;
        } 
    }
}