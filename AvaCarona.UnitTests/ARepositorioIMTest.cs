using AvaCarona.API.Domain;
using AvaCarona.API.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AvaCarona.UnitTests
{
    [TestClass]
    public class ARepositorioIMTest
    {
        [TestMethod]
        public void AddEntity_ConfereIdTest()
        {
            var repository = new ARepositoryIM<Carona>();

            Carona caronaGuardada = repository.Add(Carona.CreateCarona(1, new Colaborador()));

            int idEsperado = 1;

            Assert.AreEqual(idEsperado, caronaGuardada.Id);

        }

        [TestMethod]
        public void DeleteEntity_ConfereIdTest()
        {
            var repository = new ARepositoryIM<Carona>();

            var carona = Carona.CreateCarona(1, new Colaborador());
            repository.Add(carona);

            var caronaParaDeletar = repository.Add(carona);
            repository.Add(carona);

            var idRemovido = repository.Delete(caronaParaDeletar);

            Assert.AreEqual(caronaParaDeletar.Id, idRemovido);
        }

        [TestMethod]
        public void List_VaziaTest()
        {
            var repository = new ARepositoryIM<Carona>();

            Assert.AreEqual(0, repository.Count);
        }

        [TestMethod]
        public void List_PreenchidaTest()
        {
            var repository = new ARepositoryIM<Carona>();

            var caronaQueNaoEhMinha = Carona.CreateCarona(1, new Colaborador());
            repository.Add(caronaQueNaoEhMinha);

            Assert.AreEqual(1, repository.Count);
        }

        [TestMethod]
        public void GetEntityById_ExisteIdTest()
        {
            var repository = new ARepositoryIM<Colaborador>();

            var colaborador = repository.Add(new Colaborador());
            repository.Add(new Colaborador());

            var colaboradorRetornado = repository.GetById(colaborador.Id);

            Assert.AreEqual(colaborador.Id, colaboradorRetornado.Id);
        }
    }
}
