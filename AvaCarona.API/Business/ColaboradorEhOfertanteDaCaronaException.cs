using System;

namespace AvaCarona.API.Business
{
    public class ColaboradorEhOfertanteDaCaronaException : Exception
    {
        private string _eid;

        public ColaboradorEhOfertanteDaCaronaException(string eid)
        {
            _eid = eid;
        }

        public override string Message => $"Este colaborador (EID: {_eid}) é o ofertante da carona e não pode ocupar uma vaga.";
    }
}