using Console_Invaders.Recursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Invaders._02sistema.Entidades
{
    class Nave : Sprite
    {

        public Nave(int x, int y) : base(x, y)
        {
            this.colorImagen = EstiloSprites._colorNave;
            this.Imagen = EstiloSprites._spriteNave;
        }

        public void Desplazar(int direccion)
        {
            bool direccionPositiva = direccion > 0;
            bool enPantalla = (this.X < RecursosVarios.ANCHO_PANTALLA - this.Imagen.Length && direccionPositiva) || 
                (this.X > 0 && !direccionPositiva);
            
            if (enPantalla)
                MoverA(this.X + (direccion * this.velocidad), this.Y);
        }
    }
}
