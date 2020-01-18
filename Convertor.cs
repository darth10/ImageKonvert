using ImageMagick;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ImageKonvert
{
    public class Convertor
    {
        public void Convert(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                throw new ArgumentException("Invalid directory.");

            foreach (string inputPath in Directory.GetFiles(directoryPath))
            {
                if (string.Equals(Path.GetExtension(inputPath), ".heic", StringComparison.OrdinalIgnoreCase))
                {
                    string outputPath =
                        Regex.Replace(inputPath, "[.]heic$", ".png", RegexOptions.IgnoreCase);
                    Convert(inputPath, outputPath);

                    Console.WriteLine($"Converted {inputPath}");
                }
            }
        }

        public void Convert(string inputPath, string outputPath)
        {
            if (!File.Exists(inputPath))
                throw new ArgumentException("Invalid input file.");

            using (MagickImage image = new MagickImage(inputPath))
            {
                image.Format = MagickFormat.Png;
                image.Write(outputPath);
            }
        }
    }
}
