using System;

namespace AvaCarona.API.Business
{
    internal class ColaboradorNaoPodeOfertarDuasCaronasNoMesmoHorarioException : Exception
    {
        public override string Message => "Um colaborador não pode ofertar duas caronas no mesmo horário.";
    }
}