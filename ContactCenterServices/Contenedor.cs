﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBL.BusinessInterfaces.CC.TH;
using ContactCenterBL.BusinessServices.CC.TH;
using ContactCenterBL.BusinessInterfaces.CC;
using ContactCenterBL.BusinessServices.CC;
using Microsoft.Practices.Unity;
using System.Diagnostics.CodeAnalysis;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using ContactCenterDA.Repositories.CC;
using ContactCenterBE.CC.TH.Entidades.LogEmailBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterBE.CC.Entidades.LogBackup;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterBE.CC.TH.Entidades.ClienteBE;
using ContactCenterBE.CC.TH.Entidades.PromocionBE;
using ContactCenterBE.CC.TH.Entidades.EmpresaBE;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBE.CC.Entidades.RolBE;
using ContactCenterServices.ServicioContactCenter;
using ContactCenterServices.ServicioTeatro;


namespace ContactCenterServices
{
    public class Contenedor
    {
        public static IUnityContainer current { get; private set; }
        static Contenedor()
        {
            current = new UnityContainer();
            //Servicio
            current.RegisterType<IServiceTeatro, ServiceTeatro>();
            current.RegisterType<IServiceContactCenter, ServiceContactCenter>();

            // Bussiness
            current.RegisterType<IAsientoService, AsientoService>();
            current.RegisterType<IAplicacionService, AplicacionService>();
            current.RegisterType<IUsuarioService, UsuarioService>();
            current.RegisterType<ILogEmailService, LogEmailService>();
            current.RegisterType<ITeatroService, TeatroService>();
            current.RegisterType<IObraService, ObraService>();
            current.RegisterType<IFuncionService, FuncionService>();
            current.RegisterType<IReservaService, ReservaService>();
            current.RegisterType<IClienteService, ClienteService>();
            current.RegisterType<ITipoPromocionService, TipoPromocionService>();
            current.RegisterType<IPromocionService, PromocionService>();
            current.RegisterType<IZonaService, ZonaService>();
            current.RegisterType<IRolService, RolService>();
            current.RegisterType<IEmpresaService, EmpresaService>();

            // Entidades - DA
            current.RegisterType<IAsientoRepository, AsientoRepository>();
            current.RegisterType<IAplicacionRepository, AplicacionRepository>();
            current.RegisterType<IUsuarioRepository, UsuarioRepository>();
            current.RegisterType<ILogEmailRepository, LogEmailRepository>();
            current.RegisterType<ITeatroRepository, TeatroRepository>();
            current.RegisterType<IObraRepository, ObraRepository>();
            current.RegisterType<IFuncionRepository, FuncionRepository>();
            current.RegisterType<IReservaRepository, ReservaRepository>();
            current.RegisterType<IClienteRepository, ClienteRepository>();
            current.RegisterType<IPromocionRepository, PromocionRepository>();
            current.RegisterType<ITipoPromocionRepository, TipoPromocionRepository>();
            current.RegisterType<IZonaRepository, ZonaRepository>();
            current.RegisterType<IRolRepository, RolRepository>();
            current.RegisterType<IEmpresaRepository, EmpresaRepository>();
            current.RegisterType<ILogBackupRepository, LogBackupRepository>();
        }
    }
}
