using CentralErros.Domain.Repositorio;
using System.Linq;
using System.Collections.Generic;
using CentralErros.Domain.Modelo;

namespace CentralErros.Data.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class, IEntity
    {
        protected readonly Contexto _contexto;
        public RepositorioBase(Contexto contexto)
        {
            _contexto = contexto;
        }

        public virtual T Incluir(T entity)
        {
            _contexto.Set<T>().Add(entity);
            _contexto.SaveChanges();
            return entity;
        }

        public virtual T Alterar(T entity)
        {
            _contexto.Set<T>().Update(entity);
            _contexto.SaveChanges();
            return entity;
        }

        public T SelecionarPorId(int id)
        {
            return _contexto.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public List<T> SelecionarTodos()
        {
            return _contexto.Set<T>().ToList();
        }

        public void Excluir(int id)
        {
            var entity = SelecionarPorId(id);
            _contexto.Set<T>().Remove(entity);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}