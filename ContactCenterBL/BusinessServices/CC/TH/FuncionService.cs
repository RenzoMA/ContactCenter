using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBL.BusinessInterfaces.CC.TH;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;

namespace ContactCenterBL.BusinessServices.CC.TH
{
    public class FuncionService : IFuncionService
    {
        private readonly IFuncionRepository _funcionRepository;
        public FuncionService(IFuncionRepository funcionRepository)
        {
            _funcionRepository = funcionRepository;
        }

        public List<Funcion> ListarFuncionDiaObra(int dia, int idObra)
        {
            List<Funcion> listaFuncion = _funcionRepository.ListarFuncionDiaObra(dia, idObra);
            Funcion funcion = new Funcion()
            {
                IdFuncion = 0,
                Horario = "Seleccione Funcion"
            };
            listaFuncion.Insert(0, funcion);
            return listaFuncion;
        }

        public bool Delete(int id) {
            return _funcionRepository.Delete(id);
        }
        public Funcion GetById(int id) {

            return _funcionRepository.GetById(id);
        }

        public IList<Funcion> GetLista() {
            return _funcionRepository.GetLista();
        }

        public bool Insert(Funcion datos) {
            return _funcionRepository.Insert(datos);
        }

        public bool Update(Funcion datos)
        {
            return _funcionRepository.Update(datos);
        }

        public List<Funcion> ListarFuncionByObra(int idObra)
        {
            List<Funcion> listaFuncion = _funcionRepository.ListarFuncionByObra(idObra);
            Funcion funcion = new Funcion()
            {
                IdFuncion = 0,
                Horario = "Seleccione Funcion"
            };
            listaFuncion.Insert(0, funcion);

            return listaFuncion;
        }
    }
}
