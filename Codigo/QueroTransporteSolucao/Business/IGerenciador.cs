using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IGerenciador<T>
    {
        bool Inserir(T objeto);
        bool Editar(T objeto);
        bool Remover(int id);
        List<T> ObterTodos();
        T ObterPorId(int id);
    }
}
