using System.Collections.Generic;

namespace app
{
    public interface IMatchFiles
    {
        IEnumerable<IContainFileInformation> MatchFiles(IEnumerable<IContainFileInformation> allFiles);
    }
}