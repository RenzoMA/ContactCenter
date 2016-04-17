using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBL.BusinessInterfaces.CC.TH;
using ContactCenterBL.BusinessServices.CC.TH;
using Microsoft.Practices.Unity;
using System.Diagnostics.CodeAnalysis;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using ContactCenterDA.Repositories.CC.TH;

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

            // Entidades - DA
            current.RegisterType<IAsientoRepository, AsientoRepository>();
        }
    }
}
