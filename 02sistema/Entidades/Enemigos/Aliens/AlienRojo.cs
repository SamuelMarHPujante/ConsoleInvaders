using Console_Invaders.Recursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Invaders._02sistema.Entidades.Enemigos.Aliens
{
    class AlienRojo : Enemigo
    {
        public AlienRojo(int x, int y) : base(x, y)
        {
            this.Puntos = DatosEntidades.PUNTOS_ALIEN_ROJO;
            this.colorImagen = EstiloSprites._colorAlienRojo;
            this.spritePrincipal = EstiloSprites._spriteAlienRojo01;
            this.spriteSecundario = EstiloSprites._spriteAlienRojo02;
            this.Imagen = spritePrincipal;
        }
    }
}
