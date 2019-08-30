
using Business;
using Persistence;
using QueroTransporte.Model;
using System.Collections.Generic;
using System.Linq;

namespace QueroTransporte.Negocio
{
    public class GerenciadorVeiculo : IGerenciador<VeiculoModel>
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;

        public GerenciadorVeiculo(BD_QUERO_TRANSPORTEContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Inseri um veiculo na base de dados
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public bool Inserir(VeiculoModel objeto)
        {
            Veiculo _veiculo = new Veiculo();

            Atribuir(objeto, _veiculo);
            _context.Add(_veiculo);
            return _context.SaveChanges() == 1 ? true : false;
        }

        /// <summary>
        /// Altera os dados de um veiculo da base de dados
        /// </summary>
        /// <param name="veiculoModel"></param>
        public bool Editar(VeiculoModel objeto)
        {
            Veiculo _veiculo = new Veiculo();

            Atribuir(objeto, _veiculo);
            _context.Update(_veiculo);
            return _context.SaveChanges() == 1 ? true : false;
        }


        /// <summary>
        /// Exclui um veiculo na base de dados
        /// </summary>
        /// <param name="id"></param>
        public bool Remover(int id)
        {
            var veiculo = _context.Veiculo.Find(id);
            _context.Veiculo.Remove(veiculo);
            return _context.SaveChanges() == 1 ? true : false;
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
            _veiculo.IdFrota = veiculoModel.IdFrota;
            _veiculo.Marca = veiculoModel.Marca;
            _veiculo.Modelo = veiculoModel.Modelo;
            _veiculo.Placa = veiculoModel.Placa;
        }

        /// <summary>
        /// Obtem todos os veiculos da base de dados
        /// </summary>
        /// <returns></returns>
        public List<VeiculoModel> ObterTodos()
            => _context.Veiculo
                .Select(veiculo => new VeiculoModel
                {
                    Id = veiculo.Id,
                    AnoFabricacao = veiculo.AnoFabricacao,
                    AnoModelo = veiculo.AnoModelo,
                    Capacidade = veiculo.Capacidade,
                    Categoria = veiculo.Categoria,
                    Chassi = veiculo.Chassi,
                    Cor = veiculo.Cor,
                    IdFrota = veiculo.IdFrota,
                    DataEmplacamento = veiculo.DataEmplacamento,
                    Marca = veiculo.Marca,
                    Modelo = veiculo.Modelo,
                    Placa = veiculo.Placa
                }).ToList();

        /// <summary>
        /// Pesquisa veiculos por modelo
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        public IEnumerable<VeiculoModel> ObterPorModelo(string modelo)
            => _context.Veiculo
                .Where(veiculoModel => veiculoModel.Modelo.StartsWith(modelo))
                .Select(veiculo => new VeiculoModel
                {
                    Id = veiculo.Id,
                    AnoFabricacao = veiculo.AnoFabricacao,
                    AnoModelo = veiculo.AnoModelo,
                    Capacidade = veiculo.Capacidade,
                    Categoria = veiculo.Categoria,
                    Chassi = veiculo.Chassi,
                    Cor = veiculo.Cor,
                    IdFrota = veiculo.IdFrota,
                    DataEmplacamento = veiculo.DataEmplacamento,
                    Marca = veiculo.Marca,
                    Modelo = veiculo.Modelo,
                    Placa = veiculo.Placa
                });

        /// <summary>
        /// Pesquisa se existe outro veiculo com o chassi ou placa passado
        /// </summary>
        /// <param name="chassi"></param>
        /// <returns></returns>
        public int VerificaInsercaoVeiculo(string chassi, string placa)
            => _context.Veiculo
                .Where(veiculoModel => veiculoModel.Chassi.StartsWith(chassi) || veiculoModel.Placa.StartsWith(placa))
                .Select(veiculo => new VeiculoModel
                {
                    Id = veiculo.Id,
                    AnoFabricacao = veiculo.AnoFabricacao,
                    AnoModelo = veiculo.AnoModelo,
                    Capacidade = veiculo.Capacidade,
                    Categoria = veiculo.Categoria,
                    Chassi = veiculo.Chassi,
                    Cor = veiculo.Cor,
                    IdFrota = veiculo.IdFrota,
                    DataEmplacamento = veiculo.DataEmplacamento,
                    Marca = veiculo.Marca,
                    Modelo = veiculo.Modelo,
                    Placa = veiculo.Placa
                }).ToList().Count();
        /// <summary>
        /// Valida campos de placa e chasse na insercao ou alteracao de um novo veiculo na base de dados
        /// </summary>
        /// <param name="chassi"></param>
        /// <param name="placa"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool VerificaEdicaoExistente(string chassi, string placa, int id)
        {
            bool existe = false;

            List<VeiculoModel> veiculosPlaca = ObterTodos().Where(veiculoModel => veiculoModel.Placa.StartsWith(placa)).ToList();
            List<VeiculoModel> veiculosChassi = ObterTodos().Where(veiculoModel => veiculoModel.Chassi.StartsWith(chassi)).ToList();


            if (veiculosPlaca.Count != 0 && veiculosChassi.Count != 0 &&
                veiculosPlaca[0].Id == id && veiculosChassi[0].Id == id)
                existe = false;
            else
            {
                if (veiculosChassi.Count() == 0)
                    existe = false;
                else
                {
                    if (veiculosChassi[0].Id != id)
                        return true;
                }

                if (veiculosPlaca.Count() == 0)
                    existe = false;
                else
                {
                    if (veiculosPlaca[0].Id != id)
                        return true;
                }
            }

            return existe;
        }

        public VeiculoModel ObterPorId(int idVeiculo)
            => _context.Veiculo.Where(v => v.Id == idVeiculo)
                .Select(v => new VeiculoModel
                {
                    Id = v.Id,
                    AnoFabricacao = v.AnoFabricacao,
                    AnoModelo = v.AnoModelo,
                    Capacidade = v.Capacidade,
                    Categoria = v.Categoria,
                    Chassi = v.Chassi,
                    Cor = v.Cor,
                    IdFrota = v.IdFrota,
                    DataEmplacamento = v.DataEmplacamento,
                    Marca = v.Marca,
                    Modelo = v.Modelo,
                    Placa = v.Placa
                }).FirstOrDefault();
    }
}