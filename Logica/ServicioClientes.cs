using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
using System.IO;

namespace Logica
{
    public class ServicioClientes
    {
        //private RepositorioClientes repositorioClientes;
        List<Cliente> clientes;
        RepositorioClientes repositorioClientes = new RepositorioClientes();

        public ServicioClientes()
        {   
            clientes = repositorioClientes.ConsultarTodos();    
        }

        public string Guardar(Cliente cliente)
        {
            try
            {
                if (repositorioClientes.Buscar(cliente.IdCliente) == null)
                {
                    repositorioClientes.Guardar(cliente);
                    Actualizar();
                    return "Se guardaron los datos de manera exitosa";
                }
                return "No es posible guardar los datos";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }

        private void Actualizar()
        {
            clientes = repositorioClientes.ConsultarTodos();
        }
        public List<Cliente> ConsultarTodos()
        {
            return clientes;
        }


        public void Eliminar(string identificacion)
        {
            //try
            //{
            //    if (repositorioClientes.Buscar(identificacion) != null)
            //    {
            //        repositorioClientes.Eliminar(identificacion);
            //        return ($"se han Eliminado Satisfactoriamente los datos del cliente con identificacion: {identificacion} ");
            //    }
            //    else
            //    {
            //        return ($"Lo sentimos, no se encuentra registrado el cliente con identificacion {identificacion}");
            //    }
            //}
            //catch (Exception e)
            //{

            //    return $"Error de la Aplicacion: {e.Message}";
            //}
        }

        public void ConsultarIdentificacion(string identificacion)
        {
            //try
            //{
            //    List<Cliente> clientes = repositorioClientes.FiltrarIdentificacion(identificacion);
            //    var response = new ClienteConsultaResponse(clientes);
            //    return response;
            //}
            //catch (Exception e)
            //{
            //    var response = new ClienteConsultaResponse("Error:" + e.Message);
            //    return response;
            //}
        }

        public class ClienteConsultaResponse
        {
            public List<Cliente> Clientes { get; set; }
            public string Message { get; set; }
            public bool Error { get; set; }
            public bool ClienteEncontrado { get; set; }
            public ClienteConsultaResponse(string message)
            {
                Error = true;
                Message = message;
                ClienteEncontrado = false;
            }
            public ClienteConsultaResponse(List<Cliente> clientes)
            {
                Clientes = clientes;
                Error = false;
                ClienteEncontrado = true;
            }

    
        }
    }
}

