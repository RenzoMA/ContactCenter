using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactCenterDA.Repositories.CC;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using System.Collections.Generic;
using ContactCenterUnitTest.GenericInterface;

namespace ContactCenterUnitTest.TH
{
    [TestClass]
    public class FuncionTest : GenericCrud
    {
        FuncionRepository funcionRepository = new FuncionRepository();
        public static Funcion funcion = new Funcion()
        {
            Dia = (int)DateTime.Now.DayOfWeek,
            Estado = "A",
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now,
            Horario = "9:00PM",
            IdFuncion = 1,
            UsuarioCreacion = "test",
            UsuarioModificacion = "test",
            Obra = ObraTest.obra
        };
        [TestMethod]
        public void Crear()
        {
            Assert.IsTrue(funcionRepository.Insert(funcion));
        }
        [TestMethod]
        public void Actualizar()
        {
            Assert.IsTrue(funcionRepository.Update(funcion));
        }
        [TestMethod]
        public void Consultar()
        {
            Assert.IsNotNull(funcionRepository.GetById(funcion.IdFuncion));
        }
        [TestMethod]
        public void Listar()
        {
            Assert.IsNotNull(funcionRepository.GetLista());
        }
        [TestMethod]
        public void Eliminar()
        {
            Assert.IsTrue(funcionRepository.Delete(funcion.IdFuncion));
        }
    }
}
