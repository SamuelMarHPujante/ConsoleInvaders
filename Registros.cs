using Console_Invaders.Recursos;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Invaders
{
    static class Registros
    {
        private const string _logDefecto = RecursosVarios._logJugador;
        
        public static void MostrarInput(ConsoleKey input) => Debug.WriteLine($"Key >\t {input}");

        public static void BorrarLog(string ficheroLog = _logDefecto)
        {
            if (File.Exists(ficheroLog))
            {
                File.Delete(ficheroLog);
            }
        }

        public static void AbrirLog(string ficheroLog = _logDefecto)
        {
            if (File.Exists(ficheroLog))
            {
                try
                {
                    using (FileStream fs = File.Open(ficheroLog, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) { }
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = ficheroLog,
                        UseShellExecute = true
                    };

                    System.Diagnostics.Process.Start(startInfo);
                }
                catch (Exception error)
                {
                    RegistrarEnLog($"Error al abrior el log: {error.Message}", ficheroLog);
                }
            }
        }

        public static void RegistrarEnLog(string registro, string destino = _logDefecto)
        {
            DateTime fechaYHora = DateTime.Now;
            using (StreamWriter registroLog = new StreamWriter(destino, true))
            {
                string mensaje = $"{fechaYHora} [Nota] \t{registro}";
                registroLog.WriteLine(mensaje);
                Debug.WriteLine(mensaje);
            }
        }
    }
}
