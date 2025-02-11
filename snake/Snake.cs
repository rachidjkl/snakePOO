using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class Snake
    {
        // Propiedades de la clase
        public int PosicionCabezaX { get; set; }
        public int PosicionCabezaY { get; set; }
        public int SerpienteSize { get; set; }

        public Snake(int posicionCabezaX, int posicionCabezaY)
        {
            PosicionCabezaX = posicionCabezaX;
            PosicionCabezaY = posicionCabezaY;
            SerpienteSize = 1;
        }
    }
}
