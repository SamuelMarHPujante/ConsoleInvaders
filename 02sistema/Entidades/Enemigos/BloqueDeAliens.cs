using Console_Invaders._02sistema.Entidades.Enemigos.Aliens;
using Console_Invaders.Recursos;
using System;
using System.Collections.Generic;

namespace Console_Invaders._02sistema.Entidades.Enemigos
{
    class BloqueDeAliens
    {
        private const int ANCHO_PANTALLA = RecursosVarios.ANCHO_PANTALLA;
        private List<Func<int, int, Enemigo>> soldados;
        private Enemigo[,] ejercito;
        private int direccion = 1;

        public BloqueDeAliens()
        {
            soldados = new List<Func<int, int, Enemigo>>()
            {
                (x, y) => new AlienVerde(x, y),
                (x, y) => new AlienRojo(x, y),
                (x, y) => new AlienAzul(x, y)
            };

            ejercito = new Enemigo[soldados.Count, DatosEntidades.CANTIDAD_ALIENS];
            FormarEjercito();
        }

        private void FormarEjercito()
        {
            int posicionInicialY = 2;
            int longitudFilas = DatosEntidades.CANTIDAD_ALIENS;
            int separacionAliens = DatosEntidades.ESPACIO_ALIENS;

            for (int i = 0; i < soldados.Count; i++)
            {
                for (int j = 0; j < longitudFilas; j++)
                {
                    int posicionX = j * separacionAliens;
                    int posicionY = i + posicionInicialY;

                    if (soldados.Count > i)
                        ejercito[i, j] = soldados[i].Invoke(posicionX, posicionY);
                }
            }
        }

        #region Métodos de movimiento de enemigos

        private Enemigo GetEnemigoAlExtremo()
        {
            Enemigo alienExtremo = null;
            bool direccionPositiva = direccion > 0;
            int extremoX = direccionPositiva ? -1 : ANCHO_PANTALLA;

            foreach (Enemigo alien in ejercito)
            {
                int alienPosX = alien.X;
                bool enPantalla = direccionPositiva ? alienPosX > extremoX : alienPosX < extremoX; 

                if (enPantalla && alien.Activo)
                {
                    extremoX = alienPosX;
                    alienExtremo = alien;
                }
            }

            return alienExtremo;
        }

        public void Mover()
        {
            bool direccionPositiva = direccion > 0;
            Enemigo referencia = GetEnemigoAlExtremo();
            bool enPantalla = referencia.X < ANCHO_PANTALLA - referencia.Imagen.Length && direccionPositiva ||
                              referencia.X > 0 && !direccionPositiva;

            if (enPantalla)
                DesplazarMatrizEnemigos();
            else
                AlternarDireccionYBajar();
        }

        private void DesplazarMatrizEnemigos()
        {
            foreach (Enemigo alien in ejercito)
            {
                if (alien.Activo)
                    alien.MoverA(alien.X + direccion, alien.Y);
            }
        }

        private void AlternarDireccionYBajar()
        {
            direccion *= -1;
            if (AjustesEnMemoria.avanceVerticalDeAliens)
            {
                foreach (Enemigo alien in ejercito)
                    alien.MoverA(alien.X, alien.Y + 1);
            }
        }

        #endregion


        public void Dibujar()
        {
            foreach (Enemigo alien in ejercito)
                alien.Dibujar();
        }
    }
}
