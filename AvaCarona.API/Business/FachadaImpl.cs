using AvaCarona.API.Domain;
using AvaCarona.API.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Business
{
    public class FachadaImpl : IFachada
    {
        private ColaboradorBusiness _colaboradorBusiness;
        private CaronaBusiness _caronaBusiness;

        public FachadaImpl(IColaboradorRepository colaboradorRepository, ICaronaRepository caronaRepository)
        {
            _colaboradorBusiness = new ColaboradorBusiness(colaboradorRepository);
            _caronaBusiness = new CaronaBusiness(caronaRepository);
        }

        public Colaborador CadastrarColaborador(Colaborador colaborador)
        {
            return _colaboradorBusiness.CadastrarColaborador(colaborador);
        }

        public Colaborador GetColaboradorById(int id)
        {
            return _colaboradorBusiness.GetById(id);
        }

        public IList<Colaborador> ListColaboradores()
        {
            return _colaboradorBusiness.List();
        }

        public int RemoverColaborador(int id)
        {
            var colaborador = new Colaborador() { Id = id };
            return _colaboradorBusiness.RemoverColaborador(colaborador);
        }

        public void UpdateColaborador(Colaborador colaborador)
        {
            _colaboradorBusiness.Update(colaborador);
        }

        public Carona CadastrarCarona(Carona carona)
        {
            return _caronaBusiness.CadastrarCarona(carona);
        }

        public Carona GetCaronaById(int id)
        {
            return _caronaBusiness.GetById(id);
        }

        public IList<Carona> ListCaronas()
        {
            return _caronaBusiness.List();
        }

        public int RemoverCarona(int id)
        {
            var carona = new Carona() { Id = id };
            return _caronaBusiness.RemoverCarona(carona);
        }
    }
}
