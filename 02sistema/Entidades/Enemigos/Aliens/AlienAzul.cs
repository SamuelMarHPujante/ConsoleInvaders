using Console_Invaders.Recursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Invaders._02sistema.Entidades.Enemigos.Aliens
{
    class AlienAzul : Enemigo
    {
        public AlienAzul(int x, int y) : base(x, y)
        {
            this.Puntos = DatosEntidades.PUNTOS_ALIEN_AZUL;
            this.colorImagen = EstiloSprites._colorAlienAzul;
            this.spritePrincipal = EstiloSprites._spriteAlienAzul01;
            this.spriteSecundario = EstiloSprites._spriteAlienAzul02;
            this.Imagen = spritePrincipal;
        }
    }
}
