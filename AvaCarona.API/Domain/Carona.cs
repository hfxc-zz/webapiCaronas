using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AvaCarona.API.Domain
{
    public class Carona : AEntidadeBaseBloqueavel
    {
        private const int LIMITE_VAGAS_SOLICITADAS = 6;

        public int OfertanteId { get; set; }

        [Required]
        public Colaborador Ofertante { get; set; }

        public DateTime DataHoraSaida { get; set; }

        public Endereco EnderecoSaida { get; set; }

        public Endereco EnderecoChegada { get; set; }

        [Required]
        public int VagasTotais { get; set; }

        public int VagasDisponiveis
        {
            get
            {
                return VagasTotais - Caroneiros.Count;
            }
        }
        public ICollection<CaronaColaborador> Caroneiros { get; set; } = new List<CaronaColaborador>();

        public Carona() : base()
        {

        }

        public void OcupeVaga(Colaborador caroneiro)
        {
            if (caroneiro == null) throw new ArgumentNullException();
            if (VagasDisponiveis <= 0) throw new EspacoInsuficienteException();
            if (JaExisteCaroneiroNaCarona(caroneiro)) throw new EsteColaboradorJaEstaNaCaronaException(caroneiro.EID);

            Caroneiros.Add(new CaronaColaborador()
            {
                CaronaId = this.Id,
                ColaboradorId = caroneiro.Id,
                Carona = this,
                Colaborador = caroneiro
            });
        }

        private bool JaExisteCaroneiroNaCarona(Colaborador caroneiro)
        {
            return Caroneiros.Any(cc => cc.ColaboradorId == caroneiro.Id);
        }

        public void DesocupeVaga(Colaborador caroneiro)
        {
            if (caroneiro == null) throw new ArgumentNullException();
            if (!JaExisteCaroneiroNaCarona(caroneiro)) throw new EsteColaboradorNaoEstaNaCaronaException(caroneiro.EID);

            var caronaColaborador = Caroneiros.Where(
                cc => cc.CaronaId == this.Id
                && cc.Carona == this
                && cc.ColaboradorId == caroneiro.Id
                && cc.Colaborador == caroneiro).FirstOrDefault();

            Caroneiros.Remove(caronaColaborador);
        }

        private Carona(int vagas, Colaborador colaborador) : base()
        {
            Ofertante = colaborador;
            VagasTotais = vagas;
        }

        public static Carona CreateCarona(int vagasSolicitadas, Colaborador ofertante)
        {
            if (ofertante == null) throw new ArgumentNullException("ofertante");
            if (vagasSolicitadas > LIMITE_VAGAS_SOLICITADAS) throw new LimiteVagasExcedidoException(vagasSolicitadas);

            var carona = new Carona(vagasSolicitadas, ofertante);
            ofertante.Caronas.Add(carona);

            return carona;
        }

        public override bool Equals(object obj)
        {
            if (obj is Carona)
            {
                var carona = obj as Carona;

                if (carona.Id == this.Id) return true;
                if (carona.OfertanteId == this.OfertanteId
                    && carona.DataHoraSaida == this.DataHoraSaida) return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"Carona: [Ofertante: {Ofertante.Nome}, DataHoraSaida: {DataHoraSaida.ToString()}]";
        }
    }
}
