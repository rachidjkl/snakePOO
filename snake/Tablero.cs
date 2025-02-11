using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class Tablero
    {
        public string[,] TableroArr { get; set; }
        public int Tamano { get; set; }
        public string DireccionMovimiento { get; set; }

        public Tablero(int tamano)
        {
            
            Tamano = tamano;
            TableroArr = new string[Tamano, Tamano]; ;
            DireccionMovimiento = "w";
        }

        public  void RellenarTablero()
        {

            TableroArr = new string[Tamano, Tamano];
            for (int j = 0; j < Tamano; j++)
            {
                for (int k = 0; k < Tamano; k++)
                {
                    TableroArr[j, k] = "0";
                }
            }
            ColocarManzanas();
        }

        public void ColocarManzanas()
        {
            while (true)
            {
                Random random = new Random();
                int numRand = random.Next(0, Tamano);
                int numRand2 = random.Next(0, Tamano);
                if (TableroArr[numRand, numRand2] == "0")
                {
                    TableroArr[numRand, numRand2] = "M";
                    break;
                }
            }
        }

        public void PintarTablero()
        {
            Console.Clear();

            // Centrar Tablero
            int centroX = Console.WindowWidth / 2;
            int centroY = Console.WindowHeight / 2;

            int inicioX = centroX - (Tamano + 1);
            int inicioY = centroY - (Tamano / 2);

            Console.SetCursorPosition(inicioX, inicioY);

            //Pintar tablero con bordes
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\u256D");
            for (int col = 0; col < Tamano; col++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\u2550\u2550");
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\u256E");

            for (int fila = 0; fila < Tamano; fila++)
            {

                Console.SetCursorPosition(inicioX, inicioY + fila + 1);

                // Lado izquierdo del borde
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\u2551 ");

                for (int col = 0; col < Tamano; col++)
                {
                    if (TableroArr[fila, col] != "0")
                    {
                        if (TableroArr[fila, col] == "M")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("M ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("S ");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("0 ");
                    }
                }

                // Lado derecho del borde
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\u2551");
            }

            Console.SetCursorPosition(inicioX, inicioY + Tamano + 1);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\u2570");
            for (int col = 0; col < Tamano; col++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\u2550\u2550");
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\u256F");
        }
    }
}
