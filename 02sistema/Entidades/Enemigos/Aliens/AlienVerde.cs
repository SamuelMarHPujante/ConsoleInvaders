using Console_Invaders.Recursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Invaders._02sistema.Entidades.Enemigos.Aliens
{
    class AlienVerde : Enemigo
    {
        public AlienVerde(int x, int y) : base(x, y)
        {
            this.Puntos = DatosEntidades.PUNTOS_ALIEN_VERDE;
            this.colorImagen = EstiloSprites._colorAlienVerde;
            this.spritePrincipal = EstiloSprites._spriteAlienVerde01;
            this.spriteSecundario = EstiloSprites._spriteAlienVerde02;
            this.Imagen = spritePrincipal;
        }
    }
}
