using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactCenterDA.Repositories.CC;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.TH.Entidades.TarifaBE;
using System.Collections.Generic;
using ContactCenterUnitTest.GenericInterface;

namespace ContactCenterUnitTest.TH
{

    [TestClass]
    public class TarifaTest : GenericCrud
    {
        TarifaRepository tarifaRepository = new TarifaRepository();
        Tarifa tarifa = new Tarifa()
        {
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now,
            IdTarifa = 1,
            Obra = ObraTest.obra,
            Precio = 100,
            UsuarioCreacion = "test",
            UsuarioModificacion = "test",
            Zona = ZonaTest.zona
        };
        [TestMethod]
        public void Crear()
        {
            Assert.IsTrue(tarifaRepository.Insert(tarifa));
        }
        [TestMethod]
        public void Actualizar()
        {
            Assert.IsTrue(tarifaRepository.Update(tarifa));
        }
        [TestMethod]
        public void Consultar()
        {
            Assert.IsNotNull(tarifaRepository.GetById(tarifa.IdTarifa));
        }
        [TestMethod]
        public void Listar()
        {
            Assert.IsNotNull(tarifaRepository.GetLista());
        }
        [TestMethod]
        public void Eliminar()
        {
            Assert.IsTrue(tarifaRepository.Delete(tarifa.IdTarifa));
        }
    }
}
