using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactCenterDA.Repositories.CC;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using System.Collections.Generic;
using ContactCenterUnitTest.GenericInterface;

namespace ContactCenterUnitTest.TH
{
    [TestClass]
    public class TeatroTest : GenericCrud
    {
        TeatroRepository teatroRepository = new TeatroRepository();
        public static Teatro teatro = new Teatro()
        {
            IdTeatro = 1,
            Estado = "A",
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now,
            Nombre = "Pirandelo",
            UsuarioCreacion = "Prueba",
            UsuarioModificacion = "prueba"
            
        };
        [TestMethod]
        public void Actualizar()
        {
            teatroRepository.Update(teatro);
        }
        [TestMethod]
        public void Consultar()
        {
            teatroRepository.GetById(teatro.IdTeatro);
        }
        [TestMethod]
        public void Crear()
        {
            teatroRepository.Insert(teatro);
        }
        [TestMethod]
        public void Eliminar()
        {
            teatroRepository.Delete(teatro.IdTeatro);
        }
        [TestMethod]
        public void Listar()
        {
            teatroRepository.GetLista();
        }
    }
}
