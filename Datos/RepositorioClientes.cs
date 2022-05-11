using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Datos
{
    public class RepositorioClientes
    {
        string ruta = "Clientes.txt";
        public string Guardar(Cliente cliente)
        {
            //FileStream archivo = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(ruta, true);
            escritor.WriteLine(cliente.Linea());
            escritor.Close();
            //archivo.Close();
            return "Se guardaron los datos";
        }
        public Cliente Buscar(string identificacion)
        {
            List<Cliente> clientes = ConsultarTodos();
            foreach (var item in clientes)
            {
                if (Encontrado(item.IdCliente, identificacion))
                {
                    return item;
                }
            }
            return null;
        }
        private bool Encontrado(string IdClienteRegistrado, string IdClienteBuscado)
        {
            return IdClienteRegistrado == IdClienteBuscado;
        }

        public List<Cliente> ConsultarTodos()
        {
            List<Cliente> clientes = new List<Cliente>();
           // FileStream archivo = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(ruta);
            string linea = string.Empty;
            while (!lector.EndOfStream)
            {
                linea =lector.ReadLine();
                Cliente cliente = new Cliente(linea);       
                clientes.Add(cliente);
            }
            lector.Close();
            //archivo.Close();
            return clientes;
        }

        

        public void Eliminar(String identificacion)
        {
            List<Cliente> clienetes = new List<Cliente>();
            clienetes = ConsultarTodos();
            FileStream archivo = new FileStream(ruta, FileMode.Create);
            archivo.Close();
            foreach (var item in clienetes)
            {
                if (!Encontrado(item.IdCliente, identificacion))
                {
                    Guardar(item);
                }
            }
        }
        public void Modificar(Cliente clientefirst, Cliente clienteNew)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = ConsultarTodos();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in clientes)
            {
                if (!Encontrado(item.IdCliente, clientefirst.IdCliente))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(clienteNew);
                }
            }
        }

        public List<Cliente> FiltrarIdentificacion(string identificacion)
        {
            return ConsultarTodos().Where(p => p.IdCliente.Equals(identificacion)).ToList();
        }

    }
}

