using AvaCarona.API.Domain;
using AvaCarona.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AvaCarona.API.Business
{
    public class CaronaBusiness
    {
        private ICaronaRepository _repositorio;
        public CaronaBusiness(ICaronaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public Carona CadastrarCarona(Carona carona)
        {
            if (carona == null) throw new ArgumentNullException();
            if (Existe(carona)) throw new ColaboradorNaoPodeOfertarDuasCaronasNoMesmoHorarioException();
            return _repositorio.Add(carona);
        }

        public int RemoverCarona(Carona carona)
        {
            if (carona == null) throw new ArgumentNullException();
            if (!Existe(carona)) throw new NotFoundException();

            var caronaEntity = _repositorio.Get(c => c.Equals(carona));

            return _repositorio.Delete(caronaEntity);
        }

        public void CadastrarCaroneiro(Carona carona, Colaborador colaborador)
        {
            if (!Existe(carona)) throw new NotFoundException();
            if (ChecaSeColaboradorEhOfertante(carona, colaborador)) throw new ColaboradorEhOfertanteDaCaronaException(colaborador.EID);

            carona.OcupeVaga(colaborador);
        }

        private bool Existe(Carona carona)
        {
            return _repositorio.Get(c => c.Equals(carona)) != null;
        }

        private bool ChecaSeColaboradorEhOfertante(Carona carona, Colaborador colaborador)
        {
            if (carona.Ofertante.EID == colaborador.EID) return true;

            return false;
        }

        public IList<Carona> List()
        {
            return _repositorio.List().ToList();
        }

        public IList<Carona> List(Expression<Func<Carona, bool>> predicate)
        {
            return _repositorio.List(predicate).ToList();
        }

        public Carona GetById(int id)
        {
            return _repositorio.Get(c => c.Id == id);
        }

        public IList<Carona> GetCaronaByOfertante(Colaborador ofertante)
        {
            if (ofertante == null) throw new ArgumentNullException();

            return _repositorio.List(c => c.Ofertante.Equals(ofertante)).ToList();
        }
    }
}
