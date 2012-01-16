using System.IO;

namespace app
{
    public class FileInformation : IContainFileInformation
    {
        readonly FileInfo file;

        public FileInformation(FileInfo file)
        {
            this.file = file;
        }

        public string GetFileName()
        {
            return file.FullName;
        }
    }
}