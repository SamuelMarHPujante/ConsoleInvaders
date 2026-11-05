using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Invaders._02sistema.Entidades.Enemigos
{
    class Enemigo : Sprite
    {
        protected string spritePrincipal, spriteSecundario;

        public int Puntos { get; set; }
        public bool Activo { get; set; }

        public Enemigo(int x, int y) : base(x, y)
        {
            this.Activo = true;
            //this.Imagen = spritePrincipal;
        }

        public override void Dibujar()
        {
            if (this.Activo)
            {
                base.Dibujar();
                CambiarSprite();
            }
        }

        private void CambiarSprite()
        {
            bool esSpritePrincipal = this.Imagen == spritePrincipal;
            this.Imagen = esSpritePrincipal ? spriteSecundario : spritePrincipal;
        }
    }
}
