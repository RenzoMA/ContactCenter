using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactCenterDA.Repositories.CC;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using System.Collections.Generic;
using ContactCenterUnitTest.GenericInterface;

namespace ContactCenterUnitTest.CC
{
    [TestClass]
    public class AplicacionTest : GenericCrud
    {
        AplicacionRepository aplicacionRepository = new AplicacionRepository();
        public static Aplicacion aplicacion = new Aplicacion
        {
            IdAplicacion = 1,
            Correo = "prueba@prueba.com",
            Estado = "A",
            FechaCreacion = DateTime.Now,
            FormInicio = "frmMain",
            Nombre = "Teatros",
            UsuarioCreacion = "rm",
            Version = "1.0",
            FechaModificacion = DateTime.Now,
            UsuarioModificacion = "mod"
        };

        [TestMethod]
        public void Actualizar()
        {
            Assert.IsTrue(aplicacionRepository.Update(aplicacion));
        }
        [TestMethod]
        public void Consultar()
        {
            Assert.IsNotNull(aplicacionRepository.GetById(1));
        }
        [TestMethod]
        public void Crear()
        {
            Assert.IsTrue(aplicacionRepository.Insert(aplicacion));
        }
        [TestMethod]
        public void Eliminar()
        {
            Assert.IsTrue(aplicacionRepository.Delete(aplicacion.IdAplicacion));
        }
        [TestMethod]
        public void Listar()
        {
            Assert.IsNotNull(aplicacionRepository.GetLista());
        }
        [TestMethod]
        public void ListarAplicacionUsuario()
        {
            Assert.IsNotNull(aplicacionRepository.ListarAplicacionUsuario(UsuarioTest.usuario));
        }

        [TestMethod]
        public void InsertarAplicacionUsuario()
        {
            aplicacionRepository.InsertAplicacionUsuario(UsuarioTest.usuario.IdUsuario, AplicacionTest.aplicacion.IdAplicacion);
        }
    }
}
