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
            Nombre = "Prueba",
            UsuarioCreacion = "rm",
            Version = "1.0",
            FechaModificacion = DateTime.Now,
            UsuarioModificacion = "mod"
        };

        [TestMethod]
        public void Actualizar()
        {
            aplicacionRepository.Update(aplicacion);
        }
        [TestMethod]
        public void Consultar()
        {
            aplicacionRepository.GetById(1);
        }
        [TestMethod]
        public void Crear()
        {
            aplicacionRepository.Insert(aplicacion);
        }
        [TestMethod]
        public void Eliminar()
        {
            aplicacionRepository.Delete(aplicacion.IdAplicacion);
        }
        [TestMethod]
        public void Listar()
        {
            aplicacionRepository.GetLista();
        }
        [TestMethod]
        public void ListarAplicacionUsuario()
        {
            aplicacionRepository.ListarAplicacionUsuario(UsuarioTest.usuario);
        }
    }
}
