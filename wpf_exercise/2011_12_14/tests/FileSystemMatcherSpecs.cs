#region _

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

#endregion

using System.Collections.Generic;
using Machine.Specifications;
using Rhino.Mocks;
using app;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace tests
{
    [Subject(typeof (FileSystemMatcher))]
    public class FileSystemMatcherSpecs
    {
        public class Concern : Observes<IMatchFiles, FileSystemMatcher>
        {
            public class when_matching_files_that_match : Concern
            {
                Establish context = () =>
                    {
                        matchingFile = MockRepository.GenerateMock<IContainFileInformation>();
                        stringMatcher = depends.on<IMatchStrings>();

                        fileName = "dog.txt";
                        matchingFile.setup(x => x.GetFileName()).Return(fileName);
                        stringMatcher.setup(x => x.Matches(fileName)).Return(true);
                    };

                Because of = () =>
                    result = sut.MatchFiles(matchingFile);

                It should_return_the_matching_files = () =>
                    result.ShouldContain(matchingFile);

                It should_get_the_file_name_from_the_file = () =>
                    matchingFile.received(x => x.GetFileName());

                It should_ask_the_string_matcher_if_the_filename_matches = () =>
                    stringMatcher.received(x => x.Matches(fileName));

                static IContainFileInformation matchingFile;
                static IMatchStrings stringMatcher;
                static string fileName;
                static IEnumerable<IContainFileInformation> result;
            }
        }
    }
}

#region _

// ReSharper restore UnusedMember.Global
// ReSharper restore InconsistentNaming
// ReSharper restore UnusedMember.Local

#endregion