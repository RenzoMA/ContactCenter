using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactCenterDA.Repositories.CC;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using System.Collections.Generic;
using ContactCenterUnitTest.GenericInterface;

namespace ContactCenterUnitTest.TH
{
    [TestClass]
    public class ObraTest : GenericCrud
    {
        ObraRepository obraRepository = new ObraRepository();
        public static Obra obra = new Obra()
        {
            IdObra = 1,
            Descripcion = "test",
            UsuarioCreacion = "test",
            UsuarioModificacion = "test",
            Estado = "A",
            FechaCreacion = DateTime.Now,
            FechaFin = DateTime.Now,
            FechaInicio = DateTime.Now,
            FechaModificacion = DateTime.Now,
            Nombre = "Obrita",
            Teatro = TeatroTest.teatro
        };
        [TestMethod]
        public void Crear()
        {
            Assert.IsTrue(obraRepository.Insert(obra));
        }
        [TestMethod]
        public void Actualizar()
        {
            Assert.IsTrue(obraRepository.Update(obra));
        }
        [TestMethod]
        public void Consultar()
        {
            Assert.IsNotNull(obraRepository.GetById(obra.IdObra));
        }
        [TestMethod]
        public void Listar()
        {
            Assert.IsNotNull(obraRepository.GetLista());
        }
        [TestMethod]
        public void Eliminar()
        {
            Assert.IsTrue(obraRepository.Delete(obra.IdObra));
        }
    }
}
