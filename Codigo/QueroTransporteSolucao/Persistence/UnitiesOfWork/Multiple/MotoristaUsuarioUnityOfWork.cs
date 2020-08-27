using AutoMapper;
using Data.Entities;
using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnityOfWork.Multiple;

namespace Data.UnitiesOfWork.Multiple
{
    public class MotoristaUsuarioUnityOfWork : IMotoristaUsuarioUnityOfWork
    {
        public IUsuarioRepository UsuarioRepository { get; }
        public IMotoristaRepository MotoristaRepository { get; }

        private readonly BD_QUERO_TRANSPORTEContext _context;
        private readonly IMapper _mapper;
        public MotoristaUsuarioUnityOfWork(BD_QUERO_TRANSPORTEContext context, IMapper mapper)
        {
            UsuarioRepository = new UsuarioRepository(context, mapper);
            MotoristaRepository = new MotoristaRepository(context, mapper);

            _context = context;
            _mapper = mapper;
        }

        public void BeginTransaction() => _context.Database.BeginTransaction();

        public void Commit() => _context.Database.CommitTransaction();

        public void Rollback() => _context.Database.RollbackTransaction();
    }
}
