using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactCenterDA.Repositories.CC;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using System.Collections.Generic;
using ContactCenterUnitTest.GenericInterface;


namespace ContactCenterUnitTest.TH
{
    [TestClass]
    public class ZonaTest : GenericCrud
    {
        ZonaRepository zonaRepository = new ZonaRepository();
        public static Zona zona = new Zona()
        {
            Descripcion = "NA",
            Estado = "A",
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now,
            IdZona = 1,
            Nombre = "Zonita",
            UsuarioCreacion = "test",
            UsuarioModificacion = "test",
            Teatro = TeatroTest.teatro
        };
        [TestMethod]
        public void Actualizar()
        {
            zonaRepository.Update(zona);
        }
        [TestMethod]
        public void Consultar()
        {
            zonaRepository.GetById(zona.IdZona);
        }
        [TestMethod]
        public void Crear()
        {
            zonaRepository.Insert(zona);
        }
        [TestMethod]
        public void Eliminar()
        {
            zonaRepository.Delete(zona.IdZona);
        }
        [TestMethod]
        public void Listar()
        {
            zonaRepository.GetLista();
        }
    }
}
