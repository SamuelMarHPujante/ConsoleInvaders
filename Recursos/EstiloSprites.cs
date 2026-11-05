using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Invaders.Recursos
{
    class EstiloSprites
    {
        #region Colores sprites

        public const ConsoleColor _colorNave = ConsoleColor.White;
        public const ConsoleColor _colorVendaje = ConsoleColor.Blue;
        public const ConsoleColor _colorBotiquin = ConsoleColor.Red;

        public const ConsoleColor _colorOvni = ConsoleColor.DarkYellow;
        public const ConsoleColor _colorAlienRojo = ConsoleColor.DarkRed;
        public const ConsoleColor _colorAlienVerde = ConsoleColor.DarkGreen;
        public const ConsoleColor _colorAlienAzul = ConsoleColor.DarkBlue;

        public const ConsoleColor _colorTorres = ConsoleColor.Cyan;
        public const ConsoleColor _colorBalasNave = ConsoleColor.Yellow;
        public const ConsoleColor _colorBalasAlien = ConsoleColor.Yellow;

        #endregion

        #region Aspecto sprites

        public const string _spriteNave = "/\\";
        public const char _spriteLadrillo = '*';
        public const char _spriteBala = '|';

        public const string _spriteVendaje = "(+)";
        public const string _spriteBotiquin = "[+]";

        public const string _spriteOvni01 = "(o|0|o)";
        public const string _spriteOvni02 = "(0|o|0)";

        public const string _spriteAlienRojo01 = "XX";
        public const string _spriteAlienRojo02 = "xx";

        public const string _spriteAlienVerde01 = "][";
        public const string _spriteAlienVerde02 = "[]";

        public const string _spriteAlienAzul01 = ")(";
        public const string _spriteAlienAzul02 = "()";

        #endregion

    }
}
