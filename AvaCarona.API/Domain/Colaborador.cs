using System;
using System.Collections.Generic;

namespace AvaCarona.API.Domain
{
    public class Colaborador : AEntidadeBaseBloqueavel
    {
        public string Nome { get; set; }
        public string EID { get; set; }
        public int PID { get; set; }
        public List<Carona> Caronas { get; set; } = new List<Carona>();

        public Colaborador() : base()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj is Colaborador) {
            var colab = obj as Colaborador;

            if (colab.Id == this.Id) return true;
            if (colab.EID == this.EID) return true;
            if (colab.PID == this.PID) return true;

            }

            return false;
        }

        public override string ToString()
        {
            return $"Colaborador: [Id: {Id}, EID: {EID}, PID: {PID}]";
        }
    }
}
