using System;
using System.IO;
using System.Collections;

namespace TextLogger
{
    public static class Logger
    {
        #region Métodos
        /// <summary>
        /// Método que registra un evento. Por Default se crea un directorio en la carpeta raíz del sistema, el cual se llamará _Logs. Dentro de él se creará un archivo con nombre Logs.txt para registrar los eventos anteriormente mencionados.
        /// </summary>
        /// <param name="mensaje">Mensaje para registrar en el log.</param>
        /// <param name="append">"True" indica que se anexará al archivo existente esta información, "False" indica que creará uno nuevo sólo con esta información (sobrescribirá el archivo existente).</param>
        /// <param name="prog">Nombre del programa que utiliza el Logger</param>
        public static void Logg(string mensaje, bool append, string nombrePrograma = "")
        {
            DateTime ahorita = DateTime.Now;
            string dir;
            string ruta;

            //foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
            //{
            //    if (de.Key.ToString() == "SystemDrive")
            //    {
            //        dir = de.Value + @"\_Logs";
            //        break;
            //    }
            //}
            dir = Environment.GetEnvironmentVariable("SystemDrive") + @"\_Logs";

            string archivo = "Logs_" + nombrePrograma + ".txt";

            if (string.IsNullOrEmpty(dir))
            {
                ruta = Path.Combine(dir, archivo);
            }
            else
            {
                ruta = Path.Combine(@"C:\_Logs", archivo);
            }

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            using (StreamWriter sw = new StreamWriter(ruta, append))
            {
                sw.WriteLine(" # [" + ahorita.ToString("yyyy-MM-dd HH:mm:ss") + "] => " + mensaje);
            }
        }

        /// <summary>
        /// Método que registra un evento. Por Default se crea un directorio en la carpeta raíz del sistema, el cual se llamará _Logs. Dentro de él se creará un archivo con nombre Logs.txt para registrar los eventos anteriormente mencionados. Este método siempre adjuntará al archivo del log si es que existe.
        /// </summary>
        /// <param name="mensaje">Mensaje para registrar en el log.</param>
        /// <param name="prog">Nombre del programa que utiliza el Logger</param>
        public static void Logg(string mensaje, string nombrePrograma)
        {
            Logg(mensaje, true, nombrePrograma);
        }
        #endregion
    }
}
