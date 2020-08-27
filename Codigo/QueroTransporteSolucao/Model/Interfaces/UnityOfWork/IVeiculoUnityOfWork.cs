﻿using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.UnityOfWork
{
    public interface IVeiculoUnityOfWork
    {
        IVeiculoRepository VeiculoRepository { get; }
    }
}
