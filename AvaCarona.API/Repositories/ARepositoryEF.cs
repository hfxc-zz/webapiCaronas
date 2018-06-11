using AvaCarona.API.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AvaCarona.API.Repositories
{
    public abstract class ARepositoryEF<T> : IRepository<T> where T : AEntidadeBase
    {
        private CaronaAppContext _context;

        public ARepositoryEF(CaronaAppContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            var entry = _context.Add(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public int Delete(T entity)
        {
            var entry = _context.Remove(entity);
            _context.SaveChanges();
            return entry.Entity.Id;
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            var result = _context.Set<T>().AsNoTracking().Where(predicate).FirstOrDefault();
            return result;
        }

        public T GetById(int id)
        {
            return Get(t => t.Id == id);
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            var result = _context.Set<T>().AsNoTracking().Where(predicate).ToList();
            return result;
        }

        public IEnumerable<T>  List()
        {
            return List(t => true);
        }

        public void Update(Colaborador colaborador)
        {
            _context.Update(colaborador);
            _context.SaveChanges();
        }
    }
}