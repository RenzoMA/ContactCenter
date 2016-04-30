using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactCenterDA.Repositories.CC;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using System.Collections.Generic;
using ContactCenterUnitTest.GenericInterface;

namespace ContactCenterUnitTest.TH
{
    [TestClass]
    public class DetalleReservaTest : GenericCrud
    {
        DetalleReservaRepository detalleReservaRepository = new DetalleReservaRepository();
        DetalleReserva detalleReserva = new DetalleReserva()
        {
            Asiento = (AsientoPrecio)AsientoTest.asiento,
            Estado = "A",
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now,
            IdDetalleReserva = 1,
            Precio = 20,
            UsuarioCreacion = "test",
            UsuarioModificacion = "test"
        };

        [TestMethod]
        public void Actualizar()
        {
            Assert.IsTrue(detalleReservaRepository.Update(detalleReserva));
        }
        [TestMethod]
        public void Consultar()
        {
            Assert.IsNotNull(detalleReservaRepository.GetById(detalleReserva.IdDetalleReserva));
        }
        [TestMethod]
        public void Crear()
        {
            Assert.IsTrue(detalleReservaRepository.Insert(detalleReserva));
        }
        [TestMethod]
        public void Eliminar()
        {
            Assert.IsTrue(detalleReservaRepository.Delete(detalleReserva.IdDetalleReserva));
        }
        [TestMethod]
        public void Listar()
        {
            Assert.IsNotNull(detalleReservaRepository.GetLista());
        }
    }
}
