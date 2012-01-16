using System.Collections.Generic;
using System.IO;

namespace app
{
    public class DirectoryInformation : IIterateFileSystem
    {
        readonly DirectoryInfo baseDirectory;

        DirectoryInformation(DirectoryInfo baseDirectory)
        {
            this.baseDirectory = baseDirectory;
        }

        public IEnumerable<IContainFileInformation> IterateFileSystem()
        {
            foreach (var file in baseDirectory.EnumerateFiles())
            {
                yield return new FileInformation(file);
            }

            foreach (var directory in baseDirectory.EnumerateDirectories())
            {
                var containedDirectory = new DirectoryInformation(directory);

                foreach (var fileInformation in containedDirectory.IterateFileSystem())
                {
                    yield return fileInformation;
                }
            }
        }
    }
}