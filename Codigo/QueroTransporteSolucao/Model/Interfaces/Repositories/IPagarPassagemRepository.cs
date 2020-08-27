using QueroTransporte.Model;
using System;

namespace Domain.Interfaces.Repositories
{
    public interface IPagarPassagemRepository
    {
        SolicitacaoVeiculoModel ObterViagemPorUsuarioData(int idUsuario, DateTime data);
    }
}