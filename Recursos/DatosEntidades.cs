using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Invaders.Recursos
{
    class DatosEntidades
    {
        #region Características de entidades

        public const int ANCHURA_TORRES = 6;
        public const int CANTIDAD_TORRES = 4;

        public const int ESPACIO_ALIENS = 3;
        public const int CANTIDAD_ALIENS = 10;

        public const int VIDAS_TOTALES = 3;
        public const int MUNICION_NAVE = 6;
        public const int MUNICION_ALIENS = 6;

        public const int MARGEN_OVNI = 20;

        #endregion

        #region Puntos obtenibles

        public const int PUNTOS_OVNI = 100;
        public const int PUNTOS_ALIEN_AZUL = 10;
        public const int PUNTOS_ALIEN_ROJO = 20;
        public const int PUNTOS_ALIEN_VERDE = 30;
        public const int PUNTOS_TOTALES_ENEMIGOS = PUNTOS_ALIEN_VERDE * CANTIDAD_ALIENS + PUNTOS_ALIEN_ROJO * CANTIDAD_ALIENS + PUNTOS_ALIEN_AZUL * CANTIDAD_ALIENS;

        #endregion
    }
}
