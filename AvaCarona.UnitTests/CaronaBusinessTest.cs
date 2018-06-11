using AvaCarona.API.Business;
using AvaCarona.API.Domain;
using AvaCarona.API.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;

namespace AvaCarona.UnitTests
{
    [TestClass]
    public class CaronaBusinessTest
    {
        [TestMethod]
        [ExpectedException(typeof(ColaboradorEhOfertanteDaCaronaException))]
        public void CadastrarCaroneiro_NaoDevePermitirCadastrarOfertanteComoCaroneiroTest()
        {
            var options = new DbContextOptionsBuilder<CaronaAppContext>()
                .UseInMemoryDatabase(databaseName: "Register_ofertante_as_caroneiro")
                .Options;

            using (var db = new CaronaAppContext(options))
            {
                var repositorio = new CaronaRepositoryEF(db);
                var business = new CaronaBusiness(repositorio);

                var colaborador = new Colaborador()
                {
                    EID = "h.xavier.correia"
                };

                var carona = Carona.CreateCarona(1, colaborador);
                business.CadastrarCarona(carona);

                business.CadastrarCaroneiro(carona, colaborador);
            }
        }
    }
}
