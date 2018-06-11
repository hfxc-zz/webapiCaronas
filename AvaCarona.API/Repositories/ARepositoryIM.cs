using AvaCarona.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AvaCarona.API.Repositories
{
    public class ARepositoryIM<T> : IRepository<T> where T : AEntidadeBase
    {
        private IList<T> _entidades = new List<T>();

        public int Count
        {
            get
            {
                return _entidades.Count;
            }
        }

        public T Add(T entity)
        {
            if (entity != null)
            {
                entity.Id = CalcularProximoId();
                _entidades.Add(entity);
                return entity;
            }

            return null;
        }

        private int CalcularProximoId()
        {
            if (_entidades.Count == 0) return 1;

            var ultimoId = _entidades[_entidades.Count - 1].Id;
            return ultimoId + 1;
        }

        public int Delete(T entity)
        {
            if (entity != null)
            {
                entity = GetById(entity.Id);
                _entidades.Remove(entity);

                return entity.Id;
            }

            return -1;
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _entidades.AsQueryable().Where(predicate).FirstOrDefault();
        }

        public T GetById(int id)
        {
            return _entidades.AsQueryable().Where(t => t.Id == id).FirstOrDefault();
        }

        public IEnumerable<T> List()
        {
            return _entidades;
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            return _entidades.AsQueryable().Where(predicate).ToList();
        }

        public void Update(Colaborador colaborador)
        {
            throw new NotImplementedException();
        }
    }
}
