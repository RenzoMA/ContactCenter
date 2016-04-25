﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactCenterDA.Repositories.CC;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using System.Collections.Generic;
using ContactCenterUnitTest.GenericInterface;

namespace ContactCenterUnitTest.TH
{
    [TestClass]
    public class EstadoReservaTest : GenericCrud
    {
        EstadoReservaRepository estadoReservaRepository = new EstadoReservaRepository();
        public static EstadoReserva estadoReserva = new EstadoReserva()
        {
            Estado = "A",
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now,
            IdEstadoReserva = 1,
            Nombre = "Prueba",
            UsuarioCreacion = "test",
            UsuarioModificacion = "test"
        };
        [TestMethod]
        public void Crear()
        {
            Assert.IsTrue(estadoReservaRepository.Insert(estadoReserva));
        }
        [TestMethod]
        public void Actualizar()
        {
            Assert.IsTrue(estadoReservaRepository.Update(estadoReserva));
        }
        [TestMethod]
        public void Consultar()
        {
            Assert.IsNotNull(estadoReservaRepository.GetById(estadoReserva.IdEstadoReserva));
        }
        [TestMethod]
        public void Listar()
        {
            Assert.IsNotNull(estadoReservaRepository.GetLista());
        }
        [TestMethod]
        public void Eliminar()
        {
            Assert.IsTrue(estadoReservaRepository.Delete(estadoReserva.IdEstadoReserva));
        }
    }
}