using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
     class MenuPrincipal
    {
         static void Main()
        {
            int op = 0;
            do
            {
                Console.Clear();
                Console.SetCursorPosition(15, 8); Console.Write(" M E N U   P R N C I P A L");
                Console.SetCursorPosition(20, 10); Console.Write("1. GESTION CLIENTES");
                Console.SetCursorPosition(20, 12); Console.Write("2. GESTION CUENTAS");
                //Console.SetCursorPosition(20, 14); Console.Write("3. SALIR");


                Console.SetCursorPosition(20, 20); Console.Write("9. SALIR");

                Console.SetCursorPosition(20, 24); Console.Write("Digite una opcion : ");
                Console.SetCursorPosition(40, 24); op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.Clear();
                        GClientes programa = new GClientes();
                        programa.run();
                        break;
                    case 2:
                        Console.Clear();
                        GCuentas cuentas = new GCuentas();
                        cuentas.run();
                        break;
                    case 3:
                        Console.Clear();
                        //logica.Menu_Avanzando MenuA = new logica.Menu_Avanzando();
                        //MenuA.run();
                        break;

                    default:
                        Console.Clear();
                        //Console.SetCursorPosition(15, 8); Console.Write("Opcion No Disponible ...");
                        Console.SetCursorPosition(15, 10); Console.Write("Gracias Por Usar Nuestro Aplicativo :)\n" +
                            "               By Mateo Rodrigues -- Yoriel Carvajalino ...");
                        Console.ReadKey();
                        break;
                }


            } while (op != 9);
        }
    }

}
