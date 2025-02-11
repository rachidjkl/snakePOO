using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class Jugar
    {
        public static int tamano;
        public static Boolean contJuego = true;
        public Jugar() {}

        public void EmpezarJugar(Tablero tablero, Snake snake)
        {
            Tablero tablero1 = new Tablero(tamano);
            Snake snake1 = new Snake(tamano / 2, tamano / 2);
            tablero.RellenarTablero();
            tablero.PintarTablero();

            while (contJuego)
            {
                ActualizarMapa(tablero, snake);
                if (contJuego)
                {
                    ConsoleKeyInfo direccionMovimientoIntroducida = Console.ReadKey(intercept: true);
                    tablero.DireccionMovimiento = direccionMovimientoIntroducida.Key.ToString().ToLower();
                }
            }
        }

        public static void ActualizarMapa(Tablero tablero, Snake snake)
        {
            // Movimiento
            switch (tablero.DireccionMovimiento)
            {
                case "w":
                    snake.PosicionCabezaX -= 1; // Mover arriba
                    break;
                case "s":
                    snake.PosicionCabezaX += 1; // Mover abajo
                    break;
                case "d":
                    snake.PosicionCabezaY += 1; // Mover derecha
                    break;
                case "a":
                    snake.PosicionCabezaY -= 1; // Mover izquierda
                    break;
            }
            ValidarAntesDeActualiza(tablero, snake);
        }

        public static void ValidarAntesDeActualiza(Tablero tablero, Snake snake)
        {
            if (snake.PosicionCabezaX >= 0 && snake.PosicionCabezaX < tablero.Tamano &&
                snake.PosicionCabezaY >= 0 && snake.PosicionCabezaY < tablero.Tamano)
            {
                //funcion para mover y alargar las serpiente
                if (tablero.TableroArr[snake.PosicionCabezaX, snake.PosicionCabezaY] != "M")
                {
                    if (int.Parse(tablero.TableroArr[snake.PosicionCabezaX, snake.PosicionCabezaY]) > 0)
                    {
                        Console.Clear();
                        AsciicArt2();
                    }
                    else
                    {
                        //for para mover las serpiente
                        MoverSerpiente(tablero, snake);
                        tablero.TableroArr[snake.PosicionCabezaX, snake.PosicionCabezaY] = "1";
                        tablero.PintarTablero();
                    }

                }
                else
                {
                    snake.SerpienteSize++;
                    MoverSerpiente(tablero, snake);
                    tablero.TableroArr[snake.PosicionCabezaX, snake.PosicionCabezaY] = "1";
                    tablero.ColocarManzanas();
                    tablero.PintarTablero();

                }

            }
            else
            {
                Console.Clear();
                AsciicArt2();
            }

        }

        public static void MoverSerpiente(Tablero tablero, Snake snake)
        {
            for (int j = 0; j < tablero.Tamano; j++)
            {
                for (int k = 0; k < tablero.Tamano; k++)
                {
                    if (tablero.TableroArr[j, k] != "M")
                    {
                        if (tablero.TableroArr[j, k] != "0")
                            tablero.TableroArr[j, k] = (int.Parse(tablero.TableroArr[j, k]) + 1).ToString(); ;
                        if (int.Parse(tablero.TableroArr[j, k]) > snake.SerpienteSize)
                            tablero.TableroArr[j, k] = "0";
                    }
                }
            }
        }

        public static void AsciicArt2()
        {
            String asciiArt = @"
            ┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
            ███▀▀▀██┼███▀▀▀███┼███▀█▄█▀███┼██▀▀▀
            ██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼█┼┼┼██┼██┼┼┼
            ██┼┼┼▄▄▄┼██▄▄▄▄▄██┼██┼┼┼▀┼┼┼██┼██▀▀▀
            ██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██┼┼┼
            ███▄▄▄██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██▄▄▄
            ┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
            ███▀▀▀███┼▀███┼┼██▀┼██▀▀▀┼██▀▀▀▀██▄┼
            ██┼┼┼┼┼██┼┼┼██┼┼██┼┼██┼┼┼┼██┼┼┼┼┼██┼
            ██┼┼┼┼┼██┼┼┼██┼┼██┼┼██▀▀▀┼██▄▄▄▄▄▀▀┼
            ██┼┼┼┼┼██┼┼┼██┼┼█▀┼┼██┼┼┼┼██┼┼┼┼┼██┼
            ███▄▄▄███┼┼┼─▀█▀┼┼─┼██▄▄▄┼██┼┼┼┼┼██▄
            ┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
            ┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼
            ┼┼┼┼┼┼████▄┼┼┼▄▄▄▄▄▄▄┼┼┼▄████┼┼┼┼┼┼┼
            ┼┼┼┼┼┼┼┼┼▀▀█▄█████████▄█▀▀┼┼┼┼┼┼┼┼┼┼
            ┼┼┼┼┼┼┼┼┼┼┼█████████████┼┼┼┼┼┼┼┼┼┼┼┼
            ┼┼┼┼┼┼┼┼┼┼┼██▀▀▀███▀▀▀██┼┼┼┼┼┼┼┼┼┼┼┼
            ┼┼┼┼┼┼┼┼┼┼┼██┼┼┼███┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼
            ┼┼┼┼┼┼┼┼┼┼┼█████▀▄▀█████┼┼┼┼┼┼┼┼┼┼┼┼
            ┼┼┼┼┼┼┼┼┼┼┼┼███████████┼┼┼┼┼┼┼┼┼┼┼┼┼
            ┼┼┼┼┼┼┼┼▄▄▄██┼┼█▀█▀█┼┼██▄▄▄┼┼┼┼┼┼┼┼┼
            ┼┼┼┼┼┼┼┼▀▀██┼┼┼┼┼┼┼┼┼┼┼██▀▀┼┼┼┼┼┼┼┼┼
            ┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼
            ┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
            ";
            contJuego = false;
            Console.ReadLine();

        }
    }
}
