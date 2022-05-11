using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Datos
{
    public class RepositorioCuenta
    {
        string ruta = "Clientes.txt";
        public string Guardar(Cuenta cuenta)
        {
            //FileStream archivo = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(ruta, true);
            escritor.WriteLine(cuenta.Linea());
            escritor.Close();
            //archivo.Close();
            return "Se guardaron los datos";
        }
        public Cuenta Buscar(string numcuenta)
        {
            List<Cuenta> cuentas = ConsultarTodos();
            foreach (var item in cuentas)
            {
                if (Encontrado(item.NumeroCuenta, numcuenta))
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

        public List<Cuenta> ConsultarTodos()
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            // FileStream archivo = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader lector = new StreamReader(ruta);
            string linea = string.Empty;
            while (!lector.EndOfStream)
            {
                linea = lector.ReadLine();
                Cuenta cuenta = new Cuenta(linea);
                cuentas.Add(cuenta);
            }
            lector.Close();
            //archivo.Close();
            return cuentas;
        }


        public void Eliminar(String numcuenta)
        {
            List<Cuenta> clienetes = new List<Cuenta>();
            clienetes = ConsultarTodos();
            FileStream archivo = new FileStream(ruta, FileMode.Create);
            archivo.Close();
            foreach (var item in clienetes)
            {
                if (!Encontrado(item.NumeroCuenta, numcuenta))
                {
                    Guardar(item);
                }
            }
        }
        public void Modificar(Cuenta clientefirst, Cuenta clienteNew)
        {
            List<Cuenta> clientes = new List<Cuenta>();
            clientes = ConsultarTodos();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in clientes)
            {
                if (!Encontrado(item.NumeroCuenta, clientefirst.NumeroCuenta))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(clienteNew);
                }
            }
        }

        public List<Cuenta> FiltrarIdentificacion(string numcuenta)
        {
            return ConsultarTodos().Where(p => p.NumeroCuenta.Equals(numcuenta)).ToList();
        }
    }
}
