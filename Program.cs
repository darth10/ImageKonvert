using System;

namespace ImageKonvert
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine($"Usage: ImageKonvert.exe /path/to/images/");
                Environment.Exit(1);
            }

            var convertor = new Convertor();
            convertor.Convert(args[0]);
        }
    }
}
