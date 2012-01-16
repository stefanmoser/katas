using System.Collections.Generic;

namespace app
{
    public interface IIterateFileSystem
    {
        IEnumerable<IContainFileInformation> IterateFileSystem();
    }
}