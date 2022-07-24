using System;

namespace SmartSolucionesCuba.Viderhe.Red5ServerCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            var red5ServerTempPath = args[0];

            Console.WriteLine(string.Format("Eliminando archivos temporales caducados de Red5 Server en el directorio {0}", red5ServerTempPath));
            Console.WriteLine("Por favor no cerrar esta ventana. Esta se cerrará automáticamente cuando termine este proceso ...");
            Console.WriteLine();

            var mediaboxFilePaths = System.IO.Directory.EnumerateFiles(red5ServerTempPath, "*.MediaDataBox@*", System.IO.SearchOption.TopDirectoryOnly);

            var nowDate = DateTime.Now.Date;

            foreach (var item in mediaboxFilePaths)
            {
                var mediaboxFile = new System.IO.FileInfo(item);

                if (mediaboxFile.CreationTime.Date >= nowDate) continue;

                mediaboxFile.Delete();

                Console.WriteLine(string.Format("Eliminado archivo temporal >> {0}", item));
            }
        }
    }
}
