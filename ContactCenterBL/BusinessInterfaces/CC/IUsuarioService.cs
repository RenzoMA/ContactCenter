﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.UsuarioBE;

namespace ContactCenterBL.BusinessInterfaces.CC
{
    public interface IUsuarioService
    {
        Usuario ValidarUsuario(string login, string contraseña);
    }
}
