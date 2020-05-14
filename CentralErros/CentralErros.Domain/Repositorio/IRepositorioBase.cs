using System;
using System.Collections.Generic;

namespace CentralErros.Domain.Repositorio
{
    public interface IRepositorioBase<T> : IDisposable where T : class, IEntity
    {
        T Incluir(T entity);

        T Alterar(T entity);

        T SelecionarPorId(int id);

        List<T> SelecionarTodos();

        void Excluir(int id);
    }
}
