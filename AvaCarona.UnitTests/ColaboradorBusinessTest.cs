using AvaCarona.API.Business;
using AvaCarona.API.Domain;
using AvaCarona.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AvaCarona.UnitTests
{
    [TestClass]
    public class ColaboradorBusinessTest
    {
        [TestMethod]
        public void GetByEid_OEidInformadoExisteTest()
        {
            var options = new DbContextOptionsBuilder<CaronaAppContext>()
                .UseInMemoryDatabase(databaseName: "Search_existing_eid")
                .Options;

            using (var db = new CaronaAppContext(options))
            {
                var repositorio = new ColaboradorRepositoryEF(db);
                var business = new ColaboradorBusiness(repositorio);
                var colaborador = new Colaborador() { EID = "h.xavier.correia" };
                business.CadastrarColaborador(colaborador);

                var colaboradorEncontrado = business.GetByEid("h.xavier.correia");

                Assert.AreEqual(colaborador.EID, colaboradorEncontrado.EID);
            }
        }

        [TestMethod]
        public void GetByEid_OEidInformadoNaoExisteTest()
        {
            var options = new DbContextOptionsBuilder<CaronaAppContext>()
                    .UseInMemoryDatabase(databaseName: "Search_fake_eid")
                    .Options;

            using (var db = new CaronaAppContext(options))
            {
                var repositorio = new ColaboradorRepositoryEF(db);
                var business = new ColaboradorBusiness(repositorio);
                business.CadastrarColaborador(new Colaborador() { EID = "h.xavier.correia" });

                var colaboradorEncontrado = business.GetByEid("i.ebrahim.dos.santos");

                Assert.IsNull(colaboradorEncontrado);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(JaExisteColaboradorException))]
        public void CadastrarColaborador_NaoDevePermitirCadastrarColaboradorQueJaExisteTest()
        {
            var options = new DbContextOptionsBuilder<CaronaAppContext>()
                    .UseInMemoryDatabase(databaseName: "Register_Colaborador_twice")
                    .Options;

            using (var db = new CaronaAppContext(options))
            {
                var repositorio = new ColaboradorRepositoryEF(db);
                var business = new ColaboradorBusiness(repositorio);
                business.CadastrarColaborador(new Colaborador() { EID = "h.xavier.correia" });

                var colaboradorNovo = new Colaborador()
                {
                    EID = "h.xavier.correia"
                };

                business.CadastrarColaborador(colaboradorNovo);
            }
        }

        [TestMethod]
        public void CadastrarColaborador_DevePermitirCadastrarColaboradorTest()
        {
            var options = new DbContextOptionsBuilder<CaronaAppContext>()
                    .UseInMemoryDatabase(databaseName: "Register_Colaborador_once")
                    .Options;

            using (var db = new CaronaAppContext(options))
            {
                var repositorio = new ColaboradorRepositoryEF(db);
                var business = new ColaboradorBusiness(repositorio);
                business.CadastrarColaborador(new Colaborador()
                {
                    EID = "h.xavier.correia",
                    PID = 12345678
                });

                var colaboradorNovo = new Colaborador()
                {
                    EID = "i.ebrahim.dos.santos",
                    PID = 55555555
                };

                var colaboradorRetornado = business.CadastrarColaborador(colaboradorNovo);

                Assert.IsNotNull(colaboradorRetornado);
            }

        }

        [TestMethod]
        public void List_ListaComColaboradoresTest()
        {
            var options = new DbContextOptionsBuilder<CaronaAppContext>()
                .UseInMemoryDatabase(databaseName: "Filled_list")
                .Options;

            using (var db = new CaronaAppContext(options))
            {
                var repositorio = new ColaboradorRepositoryEF(db);
                var business = new ColaboradorBusiness(repositorio);
                business.CadastrarColaborador(new Colaborador()
                {
                    EID = "h.xavier.correia",
                    PID = 12345678
                });

                var list = business.List();

                Assert.AreEqual(1, list.Count);
            }
        }

        [TestMethod]
        public void List_ListaVaziaTest()
        {
            var options = new DbContextOptionsBuilder<CaronaAppContext>()
                .UseInMemoryDatabase(databaseName: "Empty_list")
                .Options;

            using (var db = new CaronaAppContext(options))
            {
                var repositorio = new ColaboradorRepositoryEF(db);
                var business = new ColaboradorBusiness(repositorio);

                var list = business.List();

                Assert.AreEqual(0, list.Count);
            }
        }

        [TestMethod]
        public void RemoverColaborador_RemoverColaboradorQueExisteTest()
        {
            var options = new DbContextOptionsBuilder<CaronaAppContext>()
                .UseInMemoryDatabase(databaseName: "Remove_existing_Colaborador")
                .Options;

            int idColaborador;

            using (var db = new CaronaAppContext(options))
            {
                var repositorio = new ColaboradorRepositoryEF(db);
                var business = new ColaboradorBusiness(repositorio);

                var colaborador = business.CadastrarColaborador(new Colaborador()
                {
                    EID = "h.xavier.correia",
                    PID = 12345678
                });

                idColaborador = colaborador.Id;
            }

            using (var db = new CaronaAppContext(options))
            {
                var repositorio = new ColaboradorRepositoryEF(db);
                var business = new ColaboradorBusiness(repositorio);

                int idRemovido = business.RemoverColaborador(new Colaborador()
                {
                    EID = "h.xavier.correia",
                    PID = 12345678
                });

                Assert.AreEqual(idColaborador, idRemovido);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void RemoverColaborador_RemoverColaboradorQueNaoExisteTest()
        {
            var options = new DbContextOptionsBuilder<CaronaAppContext>()
                .UseInMemoryDatabase(databaseName: "Remove_fake_Colaborador")
                .Options;

            using (var db = new CaronaAppContext(options))
            {
                var repositorio = new ColaboradorRepositoryEF(db);
                var business = new ColaboradorBusiness(repositorio);

                int idRemovido = business.RemoverColaborador(new Colaborador()
                {
                    EID = "i.ebrahim.dos.santos",
                    PID = 55555555
                });
            }
        }
    }
}
