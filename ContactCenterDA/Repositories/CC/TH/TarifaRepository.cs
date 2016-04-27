using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.TarifaBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;

namespace ContactCenterDA.Repositories.CC.TH
{
    public class TarifaRepository : ITarifaRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Tarifa GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Tarifa> GetLista()
        {
            // gg gg gg
            throw new NotImplementedException();
        }

        public bool Insert(Tarifa datos)
        {
            throw new NotImplementedException();
        }

        public bool Update(Tarifa datos)
        {
            throw new NotImplementedException();
        }
    }
}
