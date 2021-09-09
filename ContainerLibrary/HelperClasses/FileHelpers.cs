using System;
using System.Collections.Generic;
using System.IO;

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
    }
}