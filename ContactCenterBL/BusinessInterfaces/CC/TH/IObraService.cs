using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ObraBE;

namespace ContactCenterBL.BusinessInterfaces.CC.TH
{
    public interface IObraService
    {
        List<Obra> ListarObraTeatro(int idTeatro);
        List<Obra> ListarObraTeatroCombo(int idTeatro);
        bool Delete(int id);
        Obra GetById(int id);
        IList<Obra> GetLista();
        bool Insert(Obra datos);
        bool Update(Obra datos);
        Obra GetByName(string name);
        List<Obra> ListarObraByTeatro(int idTeatro);
        List<Obra> ComboListarObraByTeatro(int idTeatro);
        List<Obra> ComboManGetListaTeatro(int idTeatro);
        byte[] GetImage(int id);
    }
}
