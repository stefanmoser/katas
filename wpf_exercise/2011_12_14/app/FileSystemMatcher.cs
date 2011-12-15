using System.Collections.Generic;

namespace app
{
    public class FileSystemMatcher : IMatchFiles
    {
        public IEnumerable<IContainFileInformation> MatchFiles(IEnumerable<IContainFileInformation> allFiles)
        {
            yield break;
        }
    }
}