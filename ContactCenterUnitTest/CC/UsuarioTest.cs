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
    public class UsuarioTest : GenericCrud
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
        public void Listar()
        {
             usuarioRepository.GetLista();
        }

        [TestMethod]
        public void Consultar()
        {
            usuarioRepository.GetById(1);
        }

        [TestMethod]
        public void Crear()
        {
            usuarioRepository.Insert(usuario);
        }

        [TestMethod]
        public void Actualizar()
        {
            usuarioRepository.Update(usuario);
        }

        [TestMethod]
        public void Eliminar()
        {
            usuarioRepository.Delete(usuario.IdUsuario);
        }

     
    }
}
