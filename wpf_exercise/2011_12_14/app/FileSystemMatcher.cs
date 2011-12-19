using System.Collections.Generic;

namespace app
{
    public class FileSystemMatcher : IMatchFiles
    {
        readonly IMatchStrings stringMatcher;

        public FileSystemMatcher(IMatchStrings stringMatcher)
        {
            this.stringMatcher = stringMatcher;
        }

        public IEnumerable<IContainFileInformation> MatchFiles(IEnumerable<IContainFileInformation> allFiles)
        {
            foreach (var file in allFiles)
            {
                var fileName = file.GetFileName();
                var matches = stringMatcher.Matches(fileName);

                if (matches)
                {
                    yield return file;
                }
            }
        }

        public IEnumerable<IContainFileInformation> MatchFiles(params IContainFileInformation[] allFiles)
        {
            return MatchFiles(new List<IContainFileInformation>(allFiles));
        }
    }
}