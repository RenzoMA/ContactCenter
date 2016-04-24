using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactCenterDA.Repositories.CC;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using System.Collections.Generic;
using ContactCenterUnitTest.GenericInterface;

namespace ContactCenterUnitTest.CC
{
    [TestClass]
    public class UsuarioTest
    {
        UsuarioRepository usuarioRepository = new UsuarioRepository();
        public static Usuario usuario = new Usuario()
        {
            IdUsuario = 1,
            Estado = "A",
            Nombre = "Renzo",
            ApellidoMaterno = "Aguilar",
            ApellidoPaterno = "Maldonado",
            Contraseña = "123",
            Correo = "renzoma89@gmail.com",
            Login = "prueba",
            Rol = new ContactCenterBE.CC.Entidades.RolBE.Rol
            {
                IdRol = 1
            },
            FechaCreacion = DateTime.Now,
            UsuarioCreacion = "renzo",
            FechaModificacion = DateTime.Now,
            UsuarioModificacion = "mod"
        };

        [TestMethod]
        public void ValidarUsuario()
        {
            usuarioRepository.ValidarUsuario(usuario.Login, usuario.Contraseña);
        }

        [TestMethod]
        public void GetLista()
        {
             usuarioRepository.GetLista();
        }

        [TestMethod]
        public void GetById()
        {
            usuarioRepository.GetById(1);
        }

        [TestMethod]
        public void Insert()
        {
            usuarioRepository.Insert(usuario);
        }

        [TestMethod]
        public void Update()
        {
            usuarioRepository.Update(usuario);
        }

        [TestMethod]
        public void Delete()
        {
            usuarioRepository.Delete(usuario.IdUsuario);
        }
    }
}
