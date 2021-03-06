﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterBE.CC.TH.Entidades.ReservaBE;
using ContactCenterBL.BusinessInterfaces.CC.TH;
using ContactCenterBE.CC.TH.Entidades.ClienteBE;
using ContactCenterBE.CC.TH.Entidades.AsientoBE;
using ContactCenterBE.CC.TH.Entidades.FuncionBE;
using ContactCenterBE.CC.TH.Entidades.PromocionBE;
using ContactCenterBE.CC.TH.Entidades.TeatroBE;
using ContactCenterBE.CC.Entidades.UsuarioBE;
using ContactCenterBE.CC.TH.Entidades.ObraBE;
using ContactCenterBE.CC.TH.Entidades.LogEmailBE;
using ContactCenterBE.CC.TH.Entidades.EmpresaBE;
using ContactCenterBL.UtilExcel;
using ContactCenterBL.Helper;
using ContactCenterCommon;


namespace ContactCenterBL.BusinessServices.CC.TH

{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository reservaRepository;
        private readonly IClienteRepository clienteRepository;
        private readonly IFuncionRepository funcionRepository;
        private readonly IObraRepository obraRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IPromocionRepository promocionRepository;
        private readonly ITeatroRepository teatroRepository;
        private readonly IAsientoRepository asientoRepository;
        private readonly ILogEmailRepository logEmailRepository;
        private readonly IEmpresaRepository empresaRepository;

        public ReservaService(IReservaRepository _reservaRepository,
                              IClienteRepository _clienteRepository,
                              IFuncionRepository _funcionRepository,
                              IObraRepository _obraRepository,
                              IUsuarioRepository _usuarioRepository,
                              IPromocionRepository _promocionRepository,
                              ITeatroRepository _teatroRepository,
                              IAsientoRepository _asientoRepository,
                              ILogEmailRepository _logEmailRepository,
                              IEmpresaRepository _empresaRepository)
        {
            reservaRepository = _reservaRepository;
            clienteRepository = _clienteRepository;
            funcionRepository = _funcionRepository;
            obraRepository = _obraRepository;
            usuarioRepository = _usuarioRepository;
            promocionRepository = _promocionRepository;
            teatroRepository = _teatroRepository;
            asientoRepository = _asientoRepository;
            logEmailRepository = _logEmailRepository;
            empresaRepository = _empresaRepository;
        }

        public bool InsertarReserva(Reserva reserva,Cliente cliente)
        {
            
            Cliente tempCliente = clienteRepository.GetByTelefono(cliente.Telefono);

            if (tempCliente == null)
            {
               cliente.IdCliente = clienteRepository.GetNewIdCliente(cliente);
            }
            else
            {
                cliente.IdCliente = tempCliente.IdCliente;
                clienteRepository.Update(cliente);
            }
            reserva.Cliente = cliente;
            
            if (reservaRepository.Insert(reserva))
            {
                List<string> email;
                email = reserva.Cliente.Correo.Replace(';',',').Split(',').ToList();
                List<string> emailCC;
                emailCC = Sesion.aplicacion.Correo.Replace(';', ',').Split(',').ToList();

                MailHelper.SendMail(email, emailCC, Enumerables.MailAction.TeatroConfirmacionReserva, logEmailRepository, reserva, null);

                return true;
            }
            else
            {
                return false;
            }

        }

        public List<DetalleReserva> ReporteReservas(int idTeatro, DateTime fecha,DateTime fechaFin)
        {
            return reservaRepository.ReporteReservasDetallado(idTeatro, fecha, fechaFin);
        }

        public List<BusquedaReserva> BuscarByNamePhoneDate(string nombrePhone, DateTime fechaInicio,DateTime fechaFin)
        {
            return reservaRepository.BuscarByNamePhoneDate(nombrePhone, fechaInicio, fechaFin);
        }

        public bool CancelarReserva(int idReserva)
        {
            return reservaRepository.CancelarReserva(idReserva);
        }

        public List<ReservaObra> ReporteReservaObra(DateTime fechaInicio, DateTime fechaFin) {
            return reservaRepository.ReporteReservaObra(fechaInicio, fechaFin);
        }

        public bool CargaMasiva(string path)
        {
            List<ExcelModelMasivo> lista = ExcelHelper.GetListaCargaMasiva(path);
            lista = lista.OrderBy(x => x.Telefono).ThenBy(x => x.FechaReserva).ThenByDescending(x => x.Obra).ToList();
            if (lista.Count == 0)
            {
                throw new Exception("El archivo se encuentra vacio");
            }
            List<Asiento> listaAsientos = new List<Asiento>();
            List<DetalleReserva> listaDetalle = new List<DetalleReserva>();
            List<Reserva> listaReservas = new List<Reserva>();
            List<String> listaPromociones = new List<string>();
            Single precio = 0;
            for (int x = 0; x<lista.Count; x++)
            {
                #region DeclararVariables

                Reserva reserva = new Reserva();
                DetalleReserva detalle;

                #endregion

                #region CapturarAsientos

                
                precio += lista[x].Precio;

                if (lista[x].Nombre == null)
                {
                    throw new Exception("Nombre debe ser ingresado en la fila: " + (x + 2));
                }
                if (lista[x].Apellidos == null)
                {
                    throw new Exception("Apellidos deben ser ingresados en la fila: " + (x + 2));
                }
                if (lista[x].Telefono == null)
                {
                    throw new Exception("Telefono debe ser ingresado en la fila: " + (x + 2));
                }
                if (lista[x].Teatro == null)
                {
                    throw new Exception("Teatro debe ser ingresado en la fila: " + (x + 2));
                }
                if (lista[x].UsuarioRegistro == null)
                {
                    throw new Exception("Usuario Registro debe ser ingresado en la fila: " + (x + 2));
                }
                if (lista[x].Zona == null)
                {
                    throw new Exception("Zona debe ser ingresada en la fila: " + (x + 2));
                }
                if (lista[x].Correo == null)
                {
                    throw new Exception("Correo debe ser ingresado en la fila: " + (x + 2));
                }
                if (lista[x].Fila == null)
                {
                    throw new Exception("Fila debe ser ingresado en la fila: " + (x + 2));
                }
                if (lista[x].Asiento == null)
                {
                    throw new Exception("Asiento debe ser ingresado en la fila: " + (x + 2));
                }
                if (lista[x].Funcion == null)
                {
                    throw new Exception("Funcion debe ser ingresado en la fila: " + (x + 2));
                }
                if (lista[x].FechaReserva == null)
                {
                    throw new Exception("Fecha Reserva debe ser ingresado en la fila: " + (x + 2));
                }
                if (lista[x].Obra == null)
                {
                    throw new Exception("Obra Reserva debe ser ingresado en la fila: " + (x + 2));
                }
               

                Teatro teatro = teatroRepository.GetLista().FirstOrDefault(te => te.Nombre.ToUpper().Trim() == lista[x].Teatro.ToUpper().Trim());
                if (teatro == null)
                {
                    throw new Exception("Teatro no encontrada en la fila: " + (x + 2));
                }
                Asiento asiento = asientoRepository.GetLista().FirstOrDefault(asi => asi.Teatro.IdTeatro == teatro.IdTeatro
                                                                                && asi.Fila == lista[x].Fila && asi.Descripcion == lista[x].Asiento);
                if (asiento == null)
                {
                    throw new Exception("Asiento no encontrado en la fila: " + (x + 2));
                }
                asiento.EstadoTemporal = lista[x].Zona;
                listaAsientos.Add(asiento);
                

                detalle = new DetalleReserva();
                detalle.Asiento = asiento;
                detalle.NombreZona = lista[x].Zona;
                detalle.FechaCreacion = DateTime.Now;
                detalle.UsuarioCreacion = lista[x].UsuarioRegistro;
                detalle.Estado = "A";
                detalle.Precio = lista[x].Precio;
                detalle.NombreFila = asiento.Fila;
                detalle.NombreAsiento = asiento.Descripcion;
                if (lista[x].Promocion != null)
                {
                    detalle.NombrePromocion = lista[x].Promocion;
                    if (!listaPromociones.Contains(lista[x].Promocion))
                    {
                        listaPromociones.Add(lista[x].Promocion);
                    }
                }
                listaDetalle.Add(detalle);

                if (x < lista.Count-1)//saltar ultima vuelta
                {
                    if (lista[x].Telefono == lista[x + 1].Telefono && lista[x].Obra == lista[x + 1].Obra && lista[x].FechaReserva == lista[x + 1].FechaReserva &&
                        lista[x].Funcion == lista[x+1].Funcion &&
                        lista[x].Teatro == lista[x+1].Teatro)
                    {
                        continue;
                    }
                }

                #endregion

                #region Obtener Datos Cabecera

                Cliente tempCliente = clienteRepository.GetByTelefono(lista[x].Telefono);
                if (tempCliente == null)
                {
                    Cliente newCliente = new Cliente()
                    {
                        Correo = lista[x].Correo,
                        Nombre = lista[x].Nombre,
                        Telefono = lista[x].Telefono,
                        ApellidoPaterno = lista[x].Apellidos,
                        Apellidomaterno = ""
                    };
                    int idCliente = clienteRepository.GetNewIdCliente(newCliente);
                }
                else
                {
                    tempCliente.Correo = lista[x].Correo;
                    tempCliente.Nombre = lista[x].Nombre;
                    tempCliente.Telefono = lista[x].Telefono;
                    tempCliente.ApellidoPaterno = lista[x].Apellidos;
                    tempCliente.Apellidomaterno = "";
                    clienteRepository.Update(tempCliente);
                }

                reserva.Cliente = tempCliente;
                reserva.Obra = obraRepository.GetLista().FirstOrDefault(ob => ob.Nombre.ToUpper().Trim() == lista[x].Obra.ToUpper().Trim());
                if (reserva.Obra == null)
                {
                    throw new Exception("Obra no encontrada en la fila: " + (x + 2));
                }
                reserva.Funcion = funcionRepository.GetLista().FirstOrDefault(fu => fu.Horario == lista[x].Funcion && fu.Obra.IdObra == reserva.Obra.IdObra);
                if (reserva.Funcion == null)
                {
                    throw new Exception("Funcion no encontrada en la fila: " + (x + 2));
                }

                reserva.Usuario = usuarioRepository.GetLista().FirstOrDefault(us => us.Login.ToUpper().Trim() == lista[x].UsuarioRegistro.ToUpper().Trim());
                if (reserva.Usuario == null)
                {
                    throw new Exception("Usuario no encontrado en la fila: " + (x + 2));
                }

                if (!String.IsNullOrEmpty(lista[x].Empresa))
                {
                    
                    Empresa objEmpresa = empresaRepository.GetLista().Where(tx => tx.Nombre.ToLower().Equals(lista[x].Empresa.ToLower())).FirstOrDefault();
                    if (objEmpresa == null)
                    {
                        throw new Exception("Empresa no encontrado en la fila: " + (x + 2));
                    }
                    else
                    {
                        reserva.Empresa = objEmpresa.Nombre;
                    }
                }
                else
                {
                    reserva.Empresa = "";
                }


                Reserva reservaExiste = reservaRepository.ReservaExiste(lista[x].FechaReserva, reserva.Funcion.IdFuncion, reserva.Cliente.IdCliente);
                if (reservaExiste != null)
                {
                    throw new Exception("Reserva ya se encuentra registrada en la fila: " + (x + 2));
                }
                

                string asientos = "";
                listaAsientos.ForEach(tx => {
                    asientos += tx.EstadoTemporal +" / " + tx.Fila + " / " + tx.Descripcion + "\n";
                });
                asientos = asientos.Substring(0, asientos.LastIndexOf("\n"));
                reserva.Asientos = asientos;
                reserva.PrecioTotal = precio;

                EstadoReserva estadoReserva = new EstadoReserva()
                {
                    IdEstadoReserva = 1,
                    Nombre = "Confirmada",
                    Estado = "A"
                };
                reserva.EstadoReserva = estadoReserva;
                
                reserva.FechaCreacion = DateTime.Now;
                reserva.UsuarioCreacion = lista[x].UsuarioRegistro;
                reserva.ListaDetalles = listaDetalle;
                reserva.FechaReserva = lista[x].FechaReserva;
                reserva.Horario = lista[x].Funcion;

                string promociones = "";
                listaPromociones.ForEach(tx => {
                    promociones += tx+",";
                });

                if (promociones.IndexOf(',') != -1)
                {
                    promociones = promociones.Substring(0, promociones.LastIndexOf(','));
                }

                reserva.NombrePromocion = promociones;
                #endregion

                #region Inserts
                listaReservas.Add(reserva);
                #endregion

                #region Limpiar valores
                listaDetalle = new List<DetalleReserva>();
                listaAsientos = new List<Asiento>();
                listaPromociones = new List<string>();
                precio = 0;
                #endregion

            }
            return reservaRepository.InsertMasivo(listaReservas);
            
        }
    }
}
