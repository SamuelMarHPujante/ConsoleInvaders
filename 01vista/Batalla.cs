using Console_Invaders._02sistema.Entidades;
using Console_Invaders._02sistema.Entidades.Enemigos;
using Console_Invaders.Recursos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Console_Invaders._01vista
{
    class Batalla
    {
        private Ovni ovni;
        private Nave jugador;
        private BloqueDeAliens ejercito;

        private int velocidadPartida = RecursosVarios.VELOCIDAD_PARTIDA_01;
        private bool batallaVictoriosa = false;     // TODO
        private bool batallaConcluida = false;      // TODO
        private bool partidaPausada = false;
        private bool ejecutando = true;

        private Dictionary<ConsoleKey, Action> opcionesVarias;
        private Dictionary<ConsoleKey, Action> controlesNave;

        public Batalla()
        {
            ovni = new Ovni(x: 0, y: 0);
            jugador = new Nave(x: RecursosVarios.ANCHO_PANTALLA / 2, y: RecursosVarios.SUELO_BATALLA - 1);
            ejercito = new BloqueDeAliens();

            this.opcionesVarias = new Dictionary<ConsoleKey, Action>
            {
                [ConsoleKey.Escape] = () => this.ejecutando = false,
                [ConsoleKey.Tab] = () => AbrirAjustes(),
                [ConsoleKey.D1] = () => CambiarVelocidadYReanudar(RecursosVarios.VELOCIDAD_PARTIDA_01),
                [ConsoleKey.D2] = () => CambiarVelocidadYReanudar(RecursosVarios.VELOCIDAD_PARTIDA_02),
                [ConsoleKey.D3] = () => CambiarVelocidadYReanudar(RecursosVarios.VELOCIDAD_PARTIDA_03),
                [ConsoleKey.Spacebar] = () => partidaPausada = !partidaPausada,
            };
            this.controlesNave = new Dictionary<ConsoleKey, Action>
            {
                [ConsoleKey.W] = () => Console.Clear(),
                [ConsoleKey.A] = () => jugador.Desplazar(direccion: -1),
                [ConsoleKey.S] = () => Console.Clear(),
                [ConsoleKey.D] = () => jugador.Desplazar(direccion: 1),
            };
        }

        public void Lanzar()
        {
            Registros.RegistrarEnLog("Partida iniciada");
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            DibujarPantalla();

            do
            {
                Thread.Sleep(velocidadPartida);
                if (Console.KeyAvailable)
                {
                    while (Console.KeyAvailable)
                        input = Console.ReadKey(true);

                    ConsoleKey llave = input.Key;
                    if (opcionesVarias.ContainsKey(llave))
                        EjecutarOrdenDe(controles: opcionesVarias, input: llave);
                    if (controlesNave.ContainsKey(llave) && !partidaPausada)
                        EjecutarOrdenDe(controles: controlesNave, input: llave);
                }

                if (!partidaPausada)
                {
                    MoverElementos();
                    // TODO ...
                }
            }
            while (ejecutando && !batallaConcluida);

            if (batallaConcluida)
                Console.WriteLine(batallaConcluida);
                //MostrarResultados();
            else
                Registros.RegistrarEnLog("Partida detenida por el jugador");
        }

        #region Métodos varios

        private void EjecutarOrdenDe(Dictionary<ConsoleKey, Action> controles, ConsoleKey input)
        {
            Registros.MostrarInput(input);
            controles[input].Invoke();
        }

        private void AbrirAjustes()
        {
            MenuAjustes ajustes = new MenuAjustes(mostrarControles: false);
            ajustes.Lanzar();
            DibujarPantalla();
        }

        private void CambiarVelocidadYReanudar(int velocidad)
        {
            partidaPausada = false;
            velocidadPartida = velocidad;
        }

        #endregion

        #region Métodos de bucle

        private void DibujarPantalla()
        {
            Console.Clear();
            jugador.Dibujar();
            ejercito.Dibujar();
        }

        private void MoverElementos()
        {
            ejercito.Mover();
            ovni.Alternar();
            ovni.Mover();
        }

        #endregion

    }
}
