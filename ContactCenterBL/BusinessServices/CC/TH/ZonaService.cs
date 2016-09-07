using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ZonaBE;
using ContactCenterBL.BusinessInterfaces.CC.TH;

namespace ContactCenterBL.BusinessServices.CC.TH
{
    public class ZonaService : IZonaService
    {
        private readonly IZonaRepository zonaRepository;
        public ZonaService(IZonaRepository _zonaRepository)
        {
            zonaRepository = _zonaRepository;
        }

        public bool ActualizarZona(Zona zona)
        {
            return zonaRepository.Update(zona);
        }

        public List<Zona> ComboListZonaByObra(int IdObra)
        {
            List<Zona> listaZona = zonaRepository.ListZonaByObra(IdObra);
            listaZona.ForEach(tx => {

                tx.Estado = tx.Estado == "A" ? "Activo" : "Inactivo";
            });
            Zona zona = new Zona()
            {
                IdZona = 0,
                Nombre = "Seleccione obra",
                Estado = "Activo"
            };
            listaZona.Insert(0, zona);
            return listaZona;
        }

        public bool InsertarZona(Zona zona)
        {
            return zonaRepository.Insert(zona);
        }

        public List<Zona> ListZonaByObra(int IdObra)
        {
            List<Zona> listaZona = zonaRepository.ListZonaByObra(IdObra);
            listaZona.ForEach(tx => {

                tx.Estado = tx.Estado == "A" ? "Activo" : "Inactivo";
            });
            return listaZona;
        }
    }
}
