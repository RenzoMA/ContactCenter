using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactCenterDA.Repositories.CC;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.Entidades.UsuarioBE;

namespace ContactCenterUnitTest
{
    [TestClass]
    public class UsuarioTest
    {
        UsuarioRepository usuarioRepository = new UsuarioRepository();

        [TestMethod]
        public void Insert()
        {

            Usuario usuario = new Usuario();
            usuario.Nombre = "Renzo";
            usuario.ApellidoMaterno = "Aguilar";
            usuario.ApellidoPaterno = "Maldonado";
            usuario.Contraseña = "123";
            usuario.Correo = "renzoma89@gmail.com";
            usuario.Login = "prueba";
            usuario.Rol = new ContactCenterBE.CC.Entidades.RolBE.Rol
            {
                IdRol = 1
            };
            usuario.FechaCreacion = DateTime.Now;
            usuario.UsuarioCreacion = "renzo";
            usuarioRepository.Insert(usuario);
        }

        [TestMethod]
        public void Update()
        {

            Usuario usuario = new Usuario();
            usuario.IdUsuario = 1;
            usuario.Nombre = "Renzo";
            usuario.ApellidoMaterno = "Aguilar";
            usuario.ApellidoPaterno = "Maldonado";
            usuario.Contraseña = "123";
            usuario.Correo = "renzoma89@gmail.com";
            usuario.Login = "prueba";

            usuario.Rol = new ContactCenterBE.CC.Entidades.RolBE.Rol
            {
                IdRol = 1
            };
            usuario.FechaCreacion = DateTime.Now;
            usuario.UsuarioCreacion = "renzo";
            usuarioRepository.Update(usuario);
        }



    }
}
