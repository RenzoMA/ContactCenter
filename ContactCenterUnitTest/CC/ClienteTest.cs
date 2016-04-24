using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactCenterDA.Repositories.CC;
using ContactCenterDA.Repositories.CC.TH;
using ContactCenterBE.CC.Entidades.CLienteBE;
using System.Collections.Generic;
using ContactCenterUnitTest.GenericInterface;

namespace ContactCenterUnitTest.CC
{
    [TestClass]
    public class ClienteTest : GenericCrud
    {
        ClienteRepository clienteRepository = new ClienteRepository();

        public static Cliente cliente = new Cliente()
        {
            IdCliente = 1,
            Apellidomaterno = "materno",
            ApellidoPaterno = "paterno",
            Correo = "cliente@prueba.com",
            FechaCreacion = DateTime.Now,
            FechaModificacion = DateTime.Now,
            Nombre = "Prueba",
            Telefono = "940429781",
            UsuarioCreacion = "rm",
            UsuarioModificacion = "prueba"
        };

        [TestMethod]
        public void Actualizar()
        {
            clienteRepository.Update(cliente);
        }
        [TestMethod]
        public void Consultar()
        {
            clienteRepository.GetById(cliente.IdCliente);
        }
        [TestMethod]
        public void Crear()
        {
            clienteRepository.Insert(cliente);
        }
        [TestMethod]
        public void Eliminar()
        {
            clienteRepository.Delete(cliente.IdCliente);
        }
        [TestMethod]
        public void Listar()
        {
            clienteRepository.GetLista();
        }
    }
}
