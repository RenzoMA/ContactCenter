using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBL.BusinessInterfaces.CC;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using ContactCenterCommon;

namespace ContactCenterBL.BusinessServices.CC
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository _usuarioRepository)
        {
            usuarioRepository = _usuarioRepository;
        }

        public bool InsertarUsuario(Usuario usuario)
        {
            usuario.Contraseña = Util.Encriptar(usuario.Contraseña);
            return usuarioRepository.Insert(usuario);
        }

        public List<Usuario> SearchByName(string name)
        {
            return usuarioRepository.SearchByName(name);
        }

        public bool UpdateUsuario(Usuario usuario,bool CambioContraseña)
        {
            if (CambioContraseña)
            {
                usuario.Contraseña = Util.Encriptar(usuario.Contraseña);
            }
            return usuarioRepository.Update(usuario);
        }

        public Usuario ValidarUsuario(string login, string contraseña)
        {
            string passwordEncriptado = Util.Encriptar(contraseña);
            return usuarioRepository.ValidarUsuario(login, passwordEncriptado);
        }
    }
}
