using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Invaders.Recursos
{
    class RecursosVarios
    {
        public const string _logJugador = "..//..//..//03datos//player.log";

        // ==========ELEMENTOS DE LA PANTALLA==========
        public const int ALTO_PANTALLA = 30;
        public const int ANCHO_PANTALLA = ALTO_PANTALLA * 16 / 9 * 2;

        public const int ALTURA_HUD = 5;
        public const int SUELO_BATALLA = ALTO_PANTALLA - ALTURA_HUD;


        // ==========VELOCIDAD DE SIMULACIÓN==========
        public const int VELOCIDAD_PARTIDA_01 = 45;
        public const int VELOCIDAD_PARTIDA_02 = 20;
        public const int VELOCIDAD_PARTIDA_03 = 5;
    }
}
