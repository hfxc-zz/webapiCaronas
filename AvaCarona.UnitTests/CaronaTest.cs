using AvaCarona.API.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AvaCarona.UnitTests
{
    [TestClass]
    public class CaronaTest
    {
        [TestMethod]
        [ExpectedException(typeof(EspacoInsuficienteException))]
        public void OcuparVaga_VagasInsuficientesTest()
        {
            // Preparação
            var carona = Carona.CreateCarona(0, new Colaborador());

            //Execução
            carona.OcupeVaga(new Colaborador());
        }

        [TestMethod]
        public void OcuparVaga_VagasSuficientesTest()
        {
            // Preparação
            var carona = Carona.CreateCarona(1, new Colaborador());

            //Execução
            carona.OcupeVaga(new Colaborador());

            var esperado = 0;
            var real = carona.VagasDisponiveis;

            //Verificação
            Assert.AreEqual(esperado, real);
        }

        [TestMethod]
        [ExpectedException(typeof(EsteColaboradorJaEstaNaCaronaException))]
        public void OcuparVaga_NaoPermitirColaboradorOcuparDuasVagasTest()
        {
            var ofertante = new Colaborador()
            {
                EID = "h.xavier.correia"
            };

            var carona = Carona.CreateCarona(5, ofertante);

            var colaborador = new Colaborador()
            {
                EID = "i.ebrahim.dos.santos"
            };

            carona.OcupeVaga(colaborador);
            carona.OcupeVaga(colaborador);
        }

        [TestMethod]
        public void DesocuparVaga_ColaboradorEstaNaCaronaTest()
        {
            // Preparação
            var carona = Carona.CreateCarona(1, new Colaborador());
            var colaborador = new Colaborador()
            {
                EID = "h.xavier.correia"
            };
            carona.OcupeVaga(colaborador);

            //Execução
            carona.DesocupeVaga(colaborador);

            Assert.AreEqual(1, carona.VagasDisponiveis);
        }

        [TestMethod]
        [ExpectedException(typeof(EsteColaboradorNaoEstaNaCaronaException))]
        public void DesocuparVaga_ColaboradorNaoEstaNaCaronaTest()
        {
            // Preparação
            var carona = Carona.CreateCarona(5, new Colaborador()
            {
                EID = "h.xavier.correia"
            });

            //Execução
            carona.DesocupeVaga(new Colaborador());
        }

        [TestMethod]
        [ExpectedException(typeof(LimiteVagasExcedidoException))]
        public void AoCriarCarona_NaoPermitirMaisDoQueSeisVagasTest()
        {
            var carona = Carona.CreateCarona(7, new Colaborador());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AoCriarCarona_NaoPermitirCriarSemOfertanteTest()
        {
            var carona = Carona.CreateCarona(2, null);
        }
    }
}
