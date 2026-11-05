using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Invaders._02sistema.Entidades
{
    abstract class Sprite
    {
        protected ConsoleColor colorImagen;
        protected int velocidad = 1;

        public int X { get; set; }
        public int Y { get; set; }
        public string Imagen { get; set; }

        public Sprite(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void MoverA(int x, int y)
        {
            Borrar();
            this.X = x;
            this.Y = y;
            Dibujar();
        }

        protected void Borrar()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(new string(' ', Imagen.Length));
        }

        public virtual void Dibujar()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = colorImagen;
            Console.Write(Imagen);
            Console.ResetColor();
        }

        public bool ColisionaCon(Sprite entidad)
        {
            // TODO
            return false;
        }
    }
}
