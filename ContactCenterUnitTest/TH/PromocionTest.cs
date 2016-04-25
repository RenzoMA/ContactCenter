using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactCenterDA.Repositories.CC;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.TH.Entidades.PromocionBE;
using System.Collections.Generic;
using ContactCenterUnitTest.GenericInterface;

namespace ContactCenterUnitTest.TH
{
    [TestClass]
    public class PromocionTest : GenericCrud
    {
        PromocionRepository promocionRepository = new PromocionRepository();
        public static Promocion promocion = new Promocion()
        {
            Descripcion = "Promocion",
            Estado = "A",
            FechaCreacion = DateTime.Now,
            FechaFin = DateTime.Now,
            FechaInicio = DateTime.Now,
            FechaModificacion = DateTime.Now,
            Funcion = FuncionTest.funcion,
            IdPromocion = 1,
            UsuarioCreacion = "test",
            UsuarioModificacion = "test",
            TipoPromocion = TipoPromocionTest.tipoPromocion
        };
        [TestMethod]
        public void Actualizar()
        {
            Assert.IsTrue(promocionRepository.Update(promocion));
        }
        [TestMethod]
        public void Consultar()
        {
            Assert.IsNotNull(promocionRepository.GetById(promocion.IdPromocion));
        }
        [TestMethod]
        public void Crear()
        {
            Assert.IsTrue(promocionRepository.Insert(promocion));
        }
        [TestMethod]
        public void Eliminar()
        {
            Assert.IsTrue(promocionRepository.Delete(promocion.IdPromocion));
        }
        [TestMethod]
        public void Listar()
        {
            Assert.IsNotNull(promocionRepository.GetLista());
        }
    }
}
