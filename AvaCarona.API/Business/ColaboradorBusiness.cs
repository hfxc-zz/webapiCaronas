using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AvaCarona.API.Domain;
using AvaCarona.API.Repositories;

namespace AvaCarona.API.Business
{
    public class ColaboradorBusiness
    {
        private IColaboradorRepository _repositorio;
        public ColaboradorBusiness(IColaboradorRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public IList<Colaborador> List()
        {
            return _repositorio.List().ToList();
        }

        public IList<Colaborador> List(Expression<Func<Colaborador, bool>> predicate)
        {
            return _repositorio.List(predicate).ToList();
        }

        public Colaborador GetById(int id)
        {
            return _repositorio.Get(c => c.Id == id);
        }

        public Colaborador GetByEid(string eid)
        {
            if (eid == null) throw new ArgumentNullException();

            return _repositorio.Get(c => c.EID == eid);
        }

        public Colaborador GetByPid(int pid)
        {
            return _repositorio.Get(c => c.PID == pid);
        }

        public void Update(Colaborador colaborador)
        {
            if (colaborador == null) throw new ArgumentNullException();
            if (!Existe(colaborador)) throw new NotFoundException();

            var jaExiste = _repositorio.Get(c => c.Id != colaborador.Id && (c.EID == colaborador.EID || c.PID == colaborador.PID)) != null;
            if (jaExiste) throw new JaExisteColaboradorException(colaborador);

            _repositorio.Update(colaborador);
        }

        private bool Existe(Colaborador colaborador)
        {
            var result = _repositorio.Get(c => c.Equals(colaborador));
            return result != null;
        }

        public Colaborador CadastrarColaborador(Colaborador colaborador)
        {
            if (colaborador == null) throw new ArgumentNullException();
            if (Existe(colaborador)) throw new JaExisteColaboradorException(colaborador);

            return _repositorio.Add(colaborador);
        }

        public int RemoverColaborador(Colaborador colaborador)
        {
            if (colaborador == null) throw new ArgumentNullException();
            if (!Existe(colaborador)) throw new NotFoundException();

            var colaboradorEntity = _repositorio.Get(c => c.Equals(colaborador));

            return _repositorio.Delete(colaboradorEntity);
        }
    }
}
