using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterDA.Common;
using System.Data.OleDb;
using System.Data;

namespace ContactCenterDA.Repositories.CC.TH
{
    public class EstadoReservaRepository : IEstadoReservaRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();


        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public EstadoReserva GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<EstadoReserva> GetLista()
        {
            throw new NotImplementedException();
        }

        public bool Insert(EstadoReserva datos)
        {
            throw new NotImplementedException();
        }

        public bool Update(EstadoReserva datos)
        {
            throw new NotImplementedException();
        }
    }
}
