using Console_Invaders.Recursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Invaders._02sistema.Entidades.Enemigos
{
    class Ovni : Enemigo, ICooldown
    {
        private const int MARGEN_OVNI = DatosEntidades.MARGEN_OVNI;
        private const int ANCHO_PANTALLA = RecursosVarios.ANCHO_PANTALLA;
        private Random random = new Random();
        private int direccion = 1;
        private int cooldown;

        public Ovni(int x, int y) : base(x, y)
        {
            this.Puntos = DatosEntidades.PUNTOS_OVNI;
            this.colorImagen = EstiloSprites._colorOvni;
            this.spritePrincipal = EstiloSprites._spriteOvni01;
            this.spriteSecundario = EstiloSprites._spriteOvni02;
            this.Imagen = spritePrincipal;
            this.Activo = false;
            SetCooldown();
        }

        public void SetCooldown() => cooldown = random.Next(1, MARGEN_OVNI);

        public void Alternar()
        {
            if (AjustesEnMemoria.activarAparicionOvni)
            {
                if (cooldown <= 0)
                {
                    int intento = random.Next(MARGEN_OVNI);
                    if (intento == MARGEN_OVNI - 1)
                    {
                        this.Activo = false;
                        Borrar();

                        //if (Configuracion.ovniReviveALosEnemigos)
                        //    enemigos.IntentarRevivir();
                    }
                    else if (intento == 0)
                        this.Activo = true;

                    SetCooldown();
                }
                else
                    cooldown--;
            }
        }

        public void Mover()
        {
            if (this.Activo && AjustesEnMemoria.activarAparicionOvni)
            {
                bool enPantalla = this.X < ANCHO_PANTALLA - this.Imagen.Length && direccion > 0 ||
                                  this.X > 0 && direccion < 0;

                if (enPantalla)
                    MoverA(this.X + (direccion * this.velocidad), this.Y);
                else
                    direccion = -direccion;
            }
        }

        public override void Dibujar()
        {
            if (AjustesEnMemoria.activarAparicionOvni)
                base.Dibujar();
            else
                base.Borrar();
        }

        //public void TocaConBotiquin(Botiquin botiquin)
        //{
        //    if (GetActivo() && botiquin.GetActivo())
        //    {
        //        bool colisionaX = (botiquin.GetX() + (botiquin.GetImagen().Length - 1)) >= GetX() && botiquin.GetX() < GetX() + (GetImagen().Length - 1);
        //        bool colisionaY = botiquin.GetY() == GetY();

        //        if (colisionaX && colisionaY)
        //        {
        //            botiquin.MoverA(Configuracion.random.Next(0, Configuracion.ANCHO_PANTALLA - botiquin.GetImagen().Length), 0);
        //            botiquin.SetActivo(false);
        //        }
        //    }
        //}
    }
}
