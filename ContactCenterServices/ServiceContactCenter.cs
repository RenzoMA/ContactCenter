using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBL.BusinessInterfaces.CC.TH;
using ContactCenterBL.BusinessServices.CC.TH;

namespace ContactCenterServices
{
    public class ServiceContactCenter : IServiceContactCenter
    {
        private readonly IAsientoService asientoService;

        public ServiceContactCenter()
        {
            asientoService = new AsientoService();
        }
        
        public string prueba()
        {
            return asientoService.probarMensaje();
        }
    }
}
