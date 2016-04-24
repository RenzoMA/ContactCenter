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
    public class TipoPromocionTest : GenericCrud
    {
        TipoPromocionRepository tipoPromocionRepository = new TipoPromocionRepository();
        public static TipoPromocion tipoPromocion = new TipoPromocion()
        {
            Descripcion = "Promocion",
            Estado = "A",
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now,
            IdTipoPromocion = 1,
            UsuarioCreacion = "test",
            UsuarioModificacion = "test"
        };
        [TestMethod]
        public void Actualizar()
        {
            tipoPromocionRepository.Update(tipoPromocion);
        }
        [TestMethod]
        public void Consultar()
        {
            tipoPromocionRepository.GetById(tipoPromocion.IdTipoPromocion);
        }
        [TestMethod]
        public void Crear()
        {
            tipoPromocionRepository.Insert(tipoPromocion);
        }
        [TestMethod]
        public void Eliminar()
        {
            tipoPromocionRepository.Delete(tipoPromocion.IdTipoPromocion);
        }
        [TestMethod]
        public void Listar()
        {
            tipoPromocionRepository.GetLista();
        }
    }
}
