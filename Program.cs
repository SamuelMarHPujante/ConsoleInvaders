using Console_Invaders._01vista;
using Console_Invaders.Recursos;
using System;

namespace Console_Invaders
{
    class Program
    {
        static void Main()
        {
            Registros.BorrarLog();
            Console.SetWindowSize(RecursosVarios.ANCHO_PANTALLA, RecursosVarios.ALTO_PANTALLA);
            Console.CursorVisible = false;

            MenuPrincipal juego = new MenuPrincipal();
            juego.Lanzar();

            Registros.RegistrarEnLog("Juego finalizado");
        }
    }
}