using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Console_Invaders._01vista
{
    class MenuPrincipal : Menu
    {
        public MenuPrincipal()
        {
            this.colorMarco = ConsoleColor.Yellow;
            this.colorTitulo = ConsoleColor.Green;
            this.colorInputs = ConsoleColor.White;
            this.colorOpciones = ConsoleColor.Cyan;

            this.posicionVertical = 3;
            this.tituloMenu = "Bienvenido";
            this.patronMarco = '*';
            opciones = new Dictionary<ConsoleKey, (Func<string> Get, Action Set)>
            {
                [ConsoleKey.Escape] = (() => "Salir", () => this.ejecutando = false),
                [ConsoleKey.Enter] = (() => "Jugar", () => IniciarBatalla()),
                [ConsoleKey.Tab] = (() => "Ajustes", () => AbrirAjustes()),
                [ConsoleKey.T] = (() => "Tienda", () => AbrirTienda())
            };
        }

        private void AbrirAjustes()
        {
            MenuAjustes ajustes = new MenuAjustes(mostrarControles: false);
            ajustes.Lanzar();
            DibujarMenu();
        }

        private void IniciarBatalla()
        {
            Batalla batalla = new Batalla();
            batalla.Lanzar();
            DibujarMenu();
        }

        private void AbrirTienda()
        {
            DibujarMenu();
        }
    }
}
