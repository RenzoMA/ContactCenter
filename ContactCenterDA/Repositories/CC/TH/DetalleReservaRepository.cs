﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using System.Data.OleDb;
using System.Data;
using ContactCenterDA.Common;

namespace ContactCenterDA.Repositories.CC.TH
{
    public class DetalleReservaRepository : IDetalleReservaRepository
    {
        OleDbConnection cnx = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DetalleReserva GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<DetalleReserva> GetLista()
        {
            throw new NotImplementedException();
        }

        public bool Insert(DetalleReserva datos)
        {
            throw new NotImplementedException();
        }

        public bool Update(DetalleReserva datos)
        {
            throw new NotImplementedException();
        }
    }
}
