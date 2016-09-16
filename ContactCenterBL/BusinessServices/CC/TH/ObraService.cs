using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBL.BusinessInterfaces.CC.TH;

namespace ContactCenterBL.BusinessServices.CC.TH
{
    public class ObraService : IObraService
    {
        private readonly IObraRepository _obraRepository;
        public ObraService(IObraRepository obraRepository)
        {
            _obraRepository = obraRepository;
        }
        public List<Obra> ListarObraTeatro(int idTeatro)
        {
            List<Obra> listaObra = _obraRepository.GetListaTeatro(idTeatro);
            Obra obra = new Obra()
            {
                IdObra = 0,
                Nombre = "Seleccione obra"
            };
            listaObra.Insert(0, obra);
            return listaObra;
        }
        public List<Obra> ComboManGetListaTeatro(int idTeatro)
        {
            List<Obra> listaObraTeatro = _obraRepository.ComboManGetListaTeatro(idTeatro);
            listaObraTeatro.ForEach(tx => {

                tx.Estado = tx.Estado == "A" ? "Activo" : "Inactivo";
            });
            Obra obra = new Obra()
            {
                IdObra = 0,
                Nombre = "Seleccione obra"
            };
            listaObraTeatro.Insert(0,obra);
            return listaObraTeatro;
        }

        public List<Obra> ListarObraByTeatro(int idTeatro) {

            List<Obra> listaObraTeatro = _obraRepository.ListarObraByTeatro(idTeatro);
            listaObraTeatro.ForEach(tx => {
                
                tx.Estado = tx.Estado == "A" ? "Activo" : "Inactivo";
            });
            return listaObraTeatro;
        }

        public List<Obra> ComboListarObraByTeatro(int idTeatro)
        {

            List<Obra> listaObraTeatro = _obraRepository.ListarObraByTeatro(idTeatro);
            Obra obra = new Obra()
            {
                IdObra = 0,
                Nombre = "Seleccione obra"
            };
            listaObraTeatro.Insert(0, obra);
            listaObraTeatro.ForEach(tx => {

                tx.Estado = tx.Estado == "A" ? "Activo" : "Inactivo";
            });
            return listaObraTeatro;
        }

        public Obra GetByName(string name) {
            return _obraRepository.GetByName(name);
        }

        public bool Delete(int id) {
            return _obraRepository.Delete(id);
        }

        public Obra GetById(int id) {
            return _obraRepository.GetById(id);
        }

        public IList<Obra> GetLista() {
            return _obraRepository.GetLista();
        }

        public bool Insert(Obra obra) {
            return _obraRepository.Insert(obra);

        }

        public bool Update(Obra obra) {
            return _obraRepository.Update(obra);
        }

        public byte[] GetImage(int id)
        {
            return _obraRepository.GetImage(id);
        }
    }
}
