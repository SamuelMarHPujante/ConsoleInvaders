using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Invaders._01vista
{
    class Menu
    {
        private int tabuladoOpciones = 15;
        protected ConsoleColor colorMarco;
        protected ConsoleColor colorTitulo;
        protected ConsoleColor colorInputs;
        protected ConsoleColor colorOpciones;

        protected int posicionVertical;
        protected string tituloMenu;
        protected char patronMarco;
        protected bool ejecutando = true;
        protected Dictionary<ConsoleKey, (Func<string> Get, Action Set)> opciones;

        public virtual void Lanzar()
        {
            DibujarMenu();
            do
            {
                ConsoleKeyInfo input = new ConsoleKeyInfo();
                if (Console.KeyAvailable)
                    input = Console.ReadKey(true);

                ConsoleKey llave = input.Key;
                if (opciones.ContainsKey(llave))
                {
                    Registros.MostrarInput(llave);
                    opciones[llave].Set();
                }
            } 
            while (ejecutando);
        }

        protected virtual void DibujarMenu()
        {
            Console.Clear();
            Console.SetCursorPosition(left: 0, top: posicionVertical);

            MarcarBorde(titulo: tituloMenu);
            foreach (ConsoleKey key in opciones.Keys)
            {
                Console.ForegroundColor = colorInputs;
                Console.Write($"[{key}]");

                Console.SetCursorPosition(left: tabuladoOpciones, top: Console.CursorTop);
                Console.ForegroundColor = colorOpciones;
                Console.WriteLine(opciones[key].Get());
            }
            MarcarBorde();
            Console.ResetColor();
        }

        protected void MarcarBorde(string titulo = null)
        {
            Console.ForegroundColor = colorMarco;

            int longitudBorde = 50;
            if (titulo == null)
                Console.WriteLine(new string(patronMarco, longitudBorde));
            else
            {
                int segmentoMarco = (longitudBorde / 2) - (titulo.Length / 2);
                Console.Write(new string(patronMarco, segmentoMarco));
                Console.ForegroundColor = colorTitulo;
                Console.Write(titulo.ToUpper());
                Console.ForegroundColor = colorMarco;
                Console.WriteLine(new string(patronMarco, segmentoMarco));
            }
        }
    }
}
