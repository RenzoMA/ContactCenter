using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.LogEmailBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;

namespace ContactCenterDA.Repositories.CC.TH
{
    public class LogEmailRepository : ILogEmailRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();


        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public LogEmail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<LogEmail> GetLista()
        {
            throw new NotImplementedException();
        }

        public bool Insert(LogEmail datos)
        {
            throw new NotImplementedException();
        }

        public bool Update(LogEmail datos)
        {
            throw new NotImplementedException();
        }
    }
}
