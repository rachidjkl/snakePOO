using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace snake
{
    internal class Program
    {
        public static int Tamano = 20;
        static void Main(string[] args)
        {
            Console.WriteLine("QUE TAMAÑO QUIERES PARA EL MAPA??");
            Tamano = int.Parse(Console.ReadLine());
            Tablero tablero1 = new Tablero(Tamano);
            Snake snake1 = new Snake(Tamano/2, Tamano/2);
            Jugar jugar1 = new Jugar();

            jugar1.EmpezarJugar(tablero1, snake1);
        }
    }
}
