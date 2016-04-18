using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using System.Data.OleDb;
using System.Data;

namespace ContactCenterDA.Repositories.CC.TH
{
    public class AsientoRepository : IAsientoRepository
    {
        Access MiConex = new Access();
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dtr = default(OleDbDataReader);

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Asiento GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Asiento> GetLista()
        {
            throw new NotImplementedException();
        }

        public void Insert(Asiento datos)
        {
            throw new NotImplementedException();
        }

        public string ProbarMensaje()
        {
            cnx.ConnectionString = MiConex.GetCnx();
            return "MensajePrueba";
        }

        public void Update(Asiento datos)
        {
            throw new NotImplementedException();
        }
    }
}
