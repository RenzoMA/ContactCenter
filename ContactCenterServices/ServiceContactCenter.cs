using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.Entidades.AplicacionBE;
using ContactCenterBL.BusinessInterfaces.CC.TH;
using ContactCenterBL.BusinessInterfaces.CC;
using ContactCenterBL.BusinessServices.CC.TH;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace ContactCenterServices
{
    public class ServiceContactCenter : IServiceContactCenter
    {

        private IAsientoService _asientoService;
        private IAplicacionService _aplicacionService;
        public ServiceContactCenter(
            IAsientoService asientoService,
            IAplicacionService aplicacionService)
        {
            _asientoService = asientoService;
            _aplicacionService = aplicacionService;
        }

        public void Dispose()
        {
            _asientoService = null;
            _aplicacionService = null;
        }

        public void InsertarAplicacion(Aplicacion aplicacion)
        {
            _aplicacionService.Insertar(aplicacion);
        }

        public string prueba()
        {
            return _asientoService.probarMensaje();
        }

        public List<Aplicacion> ListarAplicaciones()
        {
            return _aplicacionService.Listar();
        }
    }
}
