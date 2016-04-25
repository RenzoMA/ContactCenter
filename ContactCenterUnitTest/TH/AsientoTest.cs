using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactCenterDA.Repositories.CC;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using System.Collections.Generic;
using ContactCenterUnitTest.GenericInterface;

namespace ContactCenterUnitTest.TH
{
    [TestClass]
    public class AsientoTest : GenericCrud
    {
        AsientoRepository asientoRepository = new AsientoRepository();
        public static Asiento asiento = new Asiento()
        {
            IdAsiento = 1,
            Descripcion = "Ninguna",
            Disponible = "S",
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now,
            Fila = "F",
            UsuarioCreacion = "test",
            UsuarioModificacion = "test",
            Zona = ZonaTest.zona
        };

        [TestMethod]
        public void Actualizar()
        {
            Assert.IsTrue(asientoRepository.Update(asiento));
        }
        [TestMethod]
        public void Consultar()
        {
            Assert.IsNotNull(asientoRepository.GetById(asiento.IdAsiento));
        }
        [TestMethod]
        public void Crear()
        {
            Assert.IsTrue(asientoRepository.Insert(asiento));
        }
        [TestMethod]
        public void Eliminar()
        {
            Assert.IsTrue(asientoRepository.Delete(asiento.IdAsiento));
        }
        [TestMethod]
        public void Listar()
        {
            Assert.IsNotNull(asientoRepository.GetLista());
        }
    }
}
