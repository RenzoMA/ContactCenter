using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactCenterDA.Repositories.CC;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.Entidades.RolBE;
using System.Collections.Generic;
using ContactCenterUnitTest.GenericInterface;

namespace ContactCenterUnitTest.CC
{
    [TestClass]
    public class RolTest : GenericCrud
    {
        RolRepository rolRepository = new RolRepository();
        public static Rol rol = new Rol()
        {
            Estado = "A",
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now,
            IdRol = 1,
            Nombre = "Rol prueba",
            UsuarioCreacion = "rmaldonado",
            UsuarioModificacion = "prueba"
        };


        [TestMethod]
        public void Actualizar()
        {
            rolRepository.Update(rol);
        }
        [TestMethod]
        public void Consultar()
        {
            rolRepository.GetById(rol.IdRol);
        }
        [TestMethod]
        public void Crear()
        {
            rolRepository.Insert(rol);
        }
        [TestMethod]
        public void Eliminar()
        {
            rolRepository.Delete(rol.IdRol);
        }
        [TestMethod]
        public void Listar()
        {
            rolRepository.Update(rol);
        }
    }

    
}
