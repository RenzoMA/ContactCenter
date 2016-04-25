using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactCenterDA.Repositories.CC;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using System.Collections.Generic;
using ContactCenterUnitTest.GenericInterface;
using ContactCenterUnitTest.CC;

namespace ContactCenterUnitTest.TH
{
    [TestClass]
    public class ReservaTest : GenericCrud
    {
        ReservaRepository reservaRepository = new ReservaRepository();
        public static Reserva reserva = new Reserva()
        {
            Cliente = ClienteTest.cliente,
            EstadoReserva = EstadoReservaTest.estadoReserva,
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now,
            Funcion = FuncionTest.funcion,
            Horario = new TimeSpan(),
            IdReserva = 1,
            NombrePromocion = "N/A",
            Obra = ObraTest.obra,
            Usuario = UsuarioTest.usuario,
            UsuarioCreacion = "test",
            UsuarioModificacion = "test",
            Promocion =  PromocionTest.promocion
        };
        [TestMethod]
        public void Crear()
        {
            Assert.IsTrue(reservaRepository.Insert(reserva));
        }
        [TestMethod]
        public void Actualizar()
        {
            Assert.IsTrue(reservaRepository.Update(reserva));
        }
        [TestMethod]
        public void Consultar()
        {
            Assert.IsNotNull(reservaRepository.GetById(reserva.IdReserva));
        }
        [TestMethod]
        public void Listar()
        {
            Assert.IsNotNull(reservaRepository.GetLista());
        }
        [TestMethod]
        public void Eliminar()
        {
            Assert.IsTrue(reservaRepository.Delete(reserva.IdReserva));
        }
    }
}
