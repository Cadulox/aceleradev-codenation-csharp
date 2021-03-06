﻿using RestauranteCodenation.Domain.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestauranteCodenation.Data.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class, IEntity
    {
        protected readonly Contexto _contexto;

        public RepositorioBase(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Incluir(T entity)
        {
            _contexto.Set<T>().Add(entity);
            _contexto.SaveChanges();
        }
        public void Alterar(T entity)
        {
            _contexto.Set<T>().Update(entity);
            _contexto.SaveChanges();
        }

        public List<T> SelecionarTodos()
        {
            return _contexto.Set<T>().ToList();
        }

        public T SelecionarPorId(int id)
        {
            return _contexto.Set<T>().FirstOrDefault(x => x.Id == id);
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
