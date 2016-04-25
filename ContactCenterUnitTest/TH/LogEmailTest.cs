﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactCenterDA.Repositories.CC;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.TH.Entidades.LogEmailBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using System.Collections.Generic;
using ContactCenterUnitTest.GenericInterface;

namespace ContactCenterUnitTest.TH
{

    [TestClass]
    public class LogEmailTest : GenericCrud
    {
        LogEmailRepository logEmailRepository = new LogEmailRepository();
        public static LogEmail logEmail = new LogEmail()
        {
            Asunto = "Asunto",
            CorreoDestino = "renzoma89@gmail.com",
            CorreoDestinoCC = "renzoma89@gmail.com",
            Descripcion = "ninguna",
            Estado = "CORRECTO",
            FechaCreacion = DateTime.Now,
            FechaEnvio = DateTime.Now,
            FechaModificacion = DateTime.Now,
            IdLog = 1,
            Mensaje = "Test Case",
            UsuarioCreacion = "test",
            UsuarioModificacion = "test",
            Reserva = ReservaTest.reserva
        };
        [TestMethod]
        public void Actualizar()
        {
            Assert.IsTrue(logEmailRepository.Update(logEmail));
        }
        [TestMethod]
        public void Consultar()
        {
            Assert.IsNotNull(logEmailRepository.GetById(logEmail.IdLog));
        }
        [TestMethod]
        public void Crear()
        {
            Assert.IsTrue(logEmailRepository.Insert(logEmail));
        }
        [TestMethod]
        public void Eliminar()
        {
            Assert.IsTrue(logEmailRepository.Delete(logEmail.IdLog));
        }
        [TestMethod]
        public void Listar()
        {
            Assert.IsNotNull(logEmailRepository.GetLista());
        }
    }
}
