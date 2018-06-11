using AvaCarona.API.Domain;
using System;

namespace AvaCarona.API.Business
{
    public class JaExisteCaronaException : Exception
    {
        private Carona _carona;
        
        public JaExisteCaronaException(Carona carona)
        {
            _carona = carona;
        }

        public override string Message => $"A carona ({_carona}) já existe.";
    }
}