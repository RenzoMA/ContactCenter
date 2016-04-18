using System;
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
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using ContactCenterDA.Repositories.CC;

namespace ContactCenterServices
{
    public class Contenedor
    {
        public static IUnityContainer current { get; private set; }
        static Contenedor()
        {
            current = new UnityContainer();
            //Servicio
            current.RegisterType<IServiceContactCenter, ServiceContactCenter>();

            // Bussiness
            current.RegisterType<IAsientoService, AsientoService>();
            current.RegisterType<IAplicacionService, AplicacionService>();

            // Entidades - DA
            current.RegisterType<IAsientoRepository, AsientoRepository>();
            current.RegisterType<IAplicacionRepository, AplicacionRepository>();
        }
    }
}
