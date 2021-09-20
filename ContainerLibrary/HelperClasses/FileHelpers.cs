using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ContainerLibrary.HelperClasses
{
    public class FileHelpers
    {
        /// <summary>
        /// Chunk/split lines in a file
        /// </summary>
        /// <param name="fileName">Existing text file</param>
        /// <param name="chunkByLines">Number of lines to chunk by</param>
        /// <returns>IEnumerable&lt;string[]&gt;</returns>
        public static IEnumerable<string[]> ChunkLines(string fileName, int chunkByLines)
        {
            if ( chunkByLines <= 0 ) throw new ArgumentOutOfRangeException(nameof(chunkByLines));

            using var reader = new StreamReader(fileName);

            while ( !reader.EndOfStream )
            {
                var set = new List<string>();

                for (var index = 0; index < chunkByLines && !reader.EndOfStream; index++)
                {
                    set.Add(reader.ReadLine());
                }

                yield return set.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Folder</param>
        /// <param name="originalExtension">File extension to change</param>
        /// <param name="replacementExtension">Replacement extension</param>
        /// <returns>success true or false, if false the exception raised</returns>
        public static (bool Success, Exception Exception) RenameExtensions(string path, string originalExtension, string replacementExtension)
        {
            try
            {
                new DirectoryInfo(path).GetFiles($"*.{originalExtension}")
                    .ToList()
                    .ForEach(currentFile =>
                    {
                        var filename = Path.ChangeExtension(currentFile.Name, $".{replacementExtension}");

                        var tempName = Path.Combine(path, filename);

                        if (File.Exists(tempName))
                        {
                            File.Delete(tempName);
                        }

                        File.Move(currentFile.Name, filename);

                    });

                return (true, null);
            }
            catch (Exception exception)
            {
                return (false, exception);
            }
        }
    }
}
