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
            Horario = new TimeSpan(),
            IdFuncion = 1,
            UsuarioCreacion = "test",
            UsuarioModificacion = "test",
            Obra = ObraTest.obra
        };
        [TestMethod]
        public void Crear()
        {
            funcionRepository.Insert(funcion);
        }
        [TestMethod]
        public void Actualizar()
        {
            funcionRepository.Update(funcion);
        }
        [TestMethod]
        public void Consultar()
        {
            funcionRepository.GetById(funcion.IdFuncion);
        }
        [TestMethod]
        public void Listar()
        {
            funcionRepository.GetLista();
        }
        [TestMethod]
        public void Eliminar()
        {
            funcionRepository.Delete(funcion.IdFuncion);
        }
    }
}
