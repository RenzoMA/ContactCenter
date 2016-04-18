using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBL.BusinessInterfaces.CC.TH;
using ContactCenterBL.BusinessServices.CC.TH;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace ContactCenterServices
{
    public class ServiceContactCenter : IServiceContactCenter
    {

        private IAsientoService _asientoService;
        public ServiceContactCenter(IAsientoService asientoService)
        {
            _asientoService = asientoService;
        }

        public void Dispose()
        {
            _asientoService = null;
        }

        public string prueba()
        {
            return _asientoService.probarMensaje();
        }

    }
}
