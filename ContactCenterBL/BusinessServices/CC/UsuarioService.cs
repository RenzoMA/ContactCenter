using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBL.BusinessInterfaces.CC;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using ContactCenterBE.CC.Entidades.LogBackup;
using ContactCenterCommon;
using System.IO;
using System.Configuration;

namespace ContactCenterBL.BusinessServices.CC
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository usuarioRepository;
        private readonly ILogBackupRepository logBackupRepository;

        public UsuarioService(IUsuarioRepository _usuarioRepository, ILogBackupRepository _logBackupRepository)
        {
            usuarioRepository = _usuarioRepository;
            logBackupRepository = _logBackupRepository;
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
        private void CreateBackup()
        {
            List<LogBackup> listaLog = logBackupRepository.GetLista().ToList();
            if (listaLog.Count == 0)
            {
                try
                {
                    String destinationPath = ConfigurationManager.AppSettings["destinationFilePath"];
                    String sourcePath = ConfigurationManager.AppSettings["sourceFilePath"];
#if DEBUG
                    if (sourcePath.Contains("reemplazame"))
                    {
                        sourcePath = sourcePath.Replace("reemplazame", Directory.GetCurrentDirectory().Replace("ContactCenterGUI\\bin\\Debug", "ContactCenterDA"));
                    }
#endif
                    String fileName = "ContactCenter-" + DateTime.Today.ToString("dd-MM-yyyy") + ".accdb";
                    String fullPath = destinationPath + @"\" + fileName;
                    Directory.CreateDirectory(destinationPath);
                    File.Copy(sourcePath, fullPath);
                    LogBackup logBackup = new LogBackup()
                    {
                        FileName = fileName,
                        ComputerName = Environment.MachineName
                    };
                    logBackupRepository.Insert(logBackup);

                }
                catch (Exception ex)
                {
                    LogBackup logBackup = new LogBackup()
                    {
                        FileName = ex.Message,
                        ComputerName = System.Environment.MachineName
                    };
                    logBackupRepository.Insert(logBackup);
                }
            }
        }
        public Usuario ValidarUsuario(string login, string contraseña)
        {
            string passwordEncriptado = Util.Encriptar(contraseña);
            Usuario usuario = usuarioRepository.ValidarUsuario(login, passwordEncriptado);
            if (usuario != null)
            {
                CreateBackup();
            }
            return usuario;
        }
    }
}
