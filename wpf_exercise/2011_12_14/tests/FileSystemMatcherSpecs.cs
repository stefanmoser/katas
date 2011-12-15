#region _
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local
#endregion

using System.Collections.Generic;
using Machine.Specifications;
using app;
using developwithpassion.specifications.rhinomocks;

namespace tests
{
    [Subject(typeof(FileSystemMatcher))]
    public class FileSystemMatcherSpecs
    {
        public class Concern : Observes<IMatchFiles, FileSystemMatcher>
        {
            public class when_matching_files : Concern
            {
                Establish context = () =>
                    {
                        var nonMatchingFile1 = new StubFile("cat.txt");
                        var nonMatchingFile2 = new StubFile("my dog.jpg");
                        firstMatch = new StubFile("dog.txt");
                        secondMatch = new StubFile("my cat.jpg");

                        allFiles = new List<IContainFileInformation>
                            {
                                nonMatchingFile1,
                                firstMatch,
                                nonMatchingFile2,
                                secondMatch
                            };
                    };

                Because of = () =>
                    result = sut.MatchFiles(allFiles);

                It should_return_the_files_that_match_the_specification = () =>
                    result.ShouldContainOnly(firstMatch, secondMatch);

                static IEnumerable<IContainFileInformation> allFiles;
                static IEnumerable<IContainFileInformation> result;
                static IContainFileInformation firstMatch;
                static IContainFileInformation secondMatch;

                class StubFile : IContainFileInformation
                {
                    public StubFile(string filename)
                    {
                        throw new System.NotImplementedException();
                    }
                }
            }
        }
    }
}

#region _
// ReSharper restore UnusedMember.Global
// ReSharper restore InconsistentNaming
// ReSharper restore UnusedMember.Local
#endregion