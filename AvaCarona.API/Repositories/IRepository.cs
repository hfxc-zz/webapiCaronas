using AvaCarona.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AvaCarona.API.Repositories
{
    public interface IRepository<T> where T : AEntidadeBase
    {
        T GetById(int id);

        T Get(Expression<Func<T, bool>> predicate);

        IEnumerable<T> List();

        IEnumerable<T> List(Expression<Func<T, bool>> predicate);

        T Add(T entity);

        int Delete(T entity);

        void Update(Colaborador colaborador);
    }
}
