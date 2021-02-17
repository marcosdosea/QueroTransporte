using AutoMapper;
using Data.Entities;
using Domain.Interfaces.Repositories;
using QueroTransporte.Model;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly ContextDB _context;
        private readonly IMapper _mapper;
        public VeiculoRepository(ContextDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public VeiculoRepository()
        {
        }

        /// <summary>
        /// Inseri um veiculo na base de dados
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public virtual bool Inserir(VeiculoModel objeto)
        {
            _context.Veiculo.Add(_mapper.Map<Veiculo>(objeto));
            return _context.SaveChanges() == 1;
        }

        /// <summary>
        /// Altera os dados de um veiculo da base de dados
        /// </summary>
        /// <param name="veiculoModel"></param>
        public virtual bool Editar(VeiculoModel objeto)
        {
            _context.Veiculo.Update(_mapper.Map<Veiculo>(objeto));
            return _context.SaveChanges() == 1;
        }


        /// <summary>
        /// Exclui um veiculo na base de dados
        /// </summary>
        /// <param name="id"></param>
        public virtual bool Remover(int id)
        {
            _context.Veiculo.Remove(_context.Veiculo.FirstOrDefault(x => x.Id == id));
            return _context.SaveChanges() == 1;
        }

        /// <summary>
        /// Obtem todos os veiculos da base de dados
        /// </summary>
        /// <returns></returns>
        public virtual List<VeiculoModel> ObterTodos()
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
        public virtual IEnumerable<VeiculoModel> ObterPorModelo(string modelo)
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
        public virtual int VerificaInsercaoVeiculo(string chassi, string placa)
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

        public virtual VeiculoModel ObterPorId(int idVeiculo)
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