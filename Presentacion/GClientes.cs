using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
//using Logica;
using Datos;

namespace Presentacion
{
      class GClientes
    {
        static double saldo, consignar = 0, retirar = 0, opcion = 0;
        static string nombre, cedula, Numcuenta;
        static RepositorioClientes repositorioClientes = new RepositorioClientes();
        //static ServicioClientes clientes = new ServicioClientes();

         public void run()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("******************************* BANCO ********************************");
                Console.WriteLine("*                                                                     *");
                Console.WriteLine("*        1. CREAR                                                  *");
                Console.WriteLine("*        2. CONSULTAR                                                 *");
                Console.WriteLine("*        3. MODIFICAR                                                   *");
                Console.WriteLine("*        4. ELIMINAR                                                 *");
                Console.WriteLine("*        5. VOLVER                                                     *");
                Console.WriteLine("*                                                                     *");
                Console.WriteLine("***********************************************************************");
                Console.Write("Digite una opcion:  ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Ingresar();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 3:
                        Retirar();
                        break;
                    case 4:
                        //Consultar();
                        break;
                    case 5:
                        break;
                }
            } while (opcion != 5);

        }
        public  void Ingresar()
        {
            RepositorioClientes clientes = new RepositorioClientes();
            Console.WriteLine("---------------------------------------");
            Console.Write("Digite su nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Digite su cedula: ");
            cedula = Console.ReadLine();
            Cliente cliente = new Cliente(cedula, nombre);
            Console.WriteLine(clientes.Guardar(cliente));
          
            RepositorioCuenta cuentas = new RepositorioCuenta();
            Console.WriteLine("Ingrese el numero numero de Cuenta: ");
            Numcuenta = Console.ReadLine();
            Console.WriteLine("Ingrese el saldo inicial: ");
            saldo = Convert.ToDouble(Console.ReadLine());
            Cuenta cuenta = new Cuenta(Numcuenta, cliente, saldo);
            Console.WriteLine(cuentas.Guardar(cuenta));
            Console.ReadKey();
        }


        static void Consultar()
        {
            RepositorioClientes clientes = new RepositorioClientes();
            Console.WriteLine("___________________");
            List<Cliente> listaclientes = clientes.ConsultarTodos();

            foreach (var item in listaclientes)
            {
                Console.WriteLine(item.IdCliente + "--" + item.Nombre);
            }


            Console.ReadKey();
        }

        public  void Retirar()
        {
            //Cliente cliente = new Cliente();
            //RepositorioCuenta repositorioCuenta = new RepositorioCuenta();
            //Console.WriteLine("Ingrese el numero de identificacion del cliente: ");
            //cedula = Console.ReadLine();
            //RepositorioClientes buscarcliente = new RepositorioClientes();
            //List<Cliente> listaclientes = buscarcliente.ConsultarTodos();

            //Cuenta cuenta = new Cuenta();


            //RepositorioCuenta cuentas = new RepositorioCuenta();
            //Console.WriteLine("Ingrese el saldo a retirar: ");
            //saldo = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine();
            //Cuenta cuenta  = new Cuenta();

            //Console.WriteLine(cuentas.Guardar(cuenta));



            Console.ReadKey();



        }

        public  void Eliminar()
        {

        }

        public  void Consignar()
        {
            RepositorioClientes clientes = new RepositorioClientes();
            Console.WriteLine("___________________");
        }

    }
}