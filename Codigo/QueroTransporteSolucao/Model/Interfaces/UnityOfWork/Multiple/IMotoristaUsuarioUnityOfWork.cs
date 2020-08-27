using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.UnityOfWork.Multiple
{
    public interface IMotoristaUsuarioUnityOfWork
    {
        IUsuarioRepository UsuarioRepository { get; }
        IMotoristaRepository MotoristaRepository { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
