using Console_Invaders.Recursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Console_Invaders._01vista
{
    class MenuAjustes : Menu
    {
        private int tabuladoOnOff = 40;
        private int tabuladoAjustes = 10;
        private bool mostrarControles;

        private Dictionary<ConsoleKey, (Func<string> Get, Action Set, Func<bool> Check)> configuraciones;

        public MenuAjustes(bool mostrarControles)
        {
            this.colorMarco = ConsoleColor.Yellow;
            this.colorTitulo = ConsoleColor.Green;
            this.colorInputs = ConsoleColor.White;
            this.colorOpciones = ConsoleColor.Cyan;

            this.posicionVertical = 0;
            this.mostrarControles = mostrarControles;
            this.tituloMenu = "Opciones";
            this.patronMarco = '=';
            IniciarDiccionarios();
        }

        private void IniciarDiccionarios()
        {
            opciones = new Dictionary<ConsoleKey, (Func<string> Get, Action Set)>
            {
                [ConsoleKey.Escape] = (() => "Cerrar", () => Thread.CurrentThread.Interrupt()),
                [ConsoleKey.Tab] = (() => "Salir", () => this.ejecutando = false),
                // tab muestra u oculta los controles
            };
            configuraciones = new Dictionary<ConsoleKey, (Func<string> Get, Action Set, Func<bool> Check)>
            {
                [ConsoleKey.Q] = (
                    () => "Avance de alienígenas", 
                    () => AlternarOpcion(ref AjustesEnMemoria.avanceVerticalDeAliens), 
                    () => AjustesEnMemoria.avanceVerticalDeAliens
                ),
                [ConsoleKey.R] = (
                    () => "Aparición del ovni", 
                    () => AlternarOpcion(ref AjustesEnMemoria.activarAparicionOvni), 
                    () => AjustesEnMemoria.activarAparicionOvni
                ),
            };
        }

        public override void Lanzar()
        {
            DibujarMenu();
            do
            {
                ConsoleKeyInfo input = new ConsoleKeyInfo();
                if (Console.KeyAvailable)
                {
                    while (Console.KeyAvailable)
                        input = Console.ReadKey(true);

                    ConsoleKey llave = input.Key;
                    if (opciones.ContainsKey(llave))
                    {
                        Registros.MostrarInput(llave);
                        opciones[llave].Set();
                    }
                    if (configuraciones.ContainsKey(llave))
                    {
                        Registros.MostrarInput(llave);
                        configuraciones[llave].Set();
                    }
                }
            }
            while (ejecutando);
        }

        protected override void DibujarMenu()
        {
            base.DibujarMenu();
            Console.WriteLine();

            MarcarBorde(titulo: "Alterables");
            foreach (ConsoleKey key in configuraciones.Keys)
            {
                Console.ForegroundColor = colorInputs;
                Console.Write($"[{key}]");
                Console.SetCursorPosition(left: tabuladoAjustes, Console.CursorTop);

                Console.ForegroundColor = colorOpciones;
                Console.Write(configuraciones[key].Get());

                Console.SetCursorPosition(left: tabuladoOnOff, Console.CursorTop);
                MostrarOnOff(configuraciones[key].Check());
            }
            MarcarBorde();
            Console.ResetColor();
        }

        #region Manejo de las opciones

        private void AlternarOpcion(ref bool condicion)
        {
            condicion = !condicion;
            Registros.RegistrarEnLog($"Ajuste alterado a {condicion.ToString().ToUpper()}");
            DibujarMenu();
        }

        private void MostrarOnOff(bool activada)
        {
            string estadoActivacion = activada ? "ON " : "OFF";
            Console.ForegroundColor = activada ? ConsoleColor.Green : ConsoleColor.DarkRed;
            Console.WriteLine(estadoActivacion);
            Console.ResetColor();
        }

        #endregion
    }
}
