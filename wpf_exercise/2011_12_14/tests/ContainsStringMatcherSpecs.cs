#region _
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local
#endregion

using Machine.Specifications;
using app;
using developwithpassion.specifications.rhinomocks;

namespace tests
{
    [Subject(typeof (ContainsStringMatcher))]
    public class ContainsStringMatcherSpecs
    {
        public class Concern : Observes<IMatchStrings, ContainsStringMatcher>
        {
            public class when_matching_a_string_that_contains_the_match_string : Concern
            {

                Establish context = () =>
                    {
                        depends.on("dog");
                        theString = "dogma.mp4";
                    };

                Because of = () =>
                    result = sut.Matches(theString);

                It should_match_the_string = () =>
                    result.ShouldBeTrue();

                static bool result;
                static string theString;
            }

            public class when_matching_a_string_that_contains_the_match_string_but_with_a_different_casing : Concern
            {
                Establish context = () =>
                    {
                        depends.on("dog");
                        theString = "Dogma.mp4";
                    };

                Because of = () =>
                    result = sut.Matches(theString);

                It should_match_the_string = () =>
                    result.ShouldBeTrue();

                static bool result;
                static string theString;
            }
        }
    }
}

#region _
// ReSharper restore UnusedMember.Global
// ReSharper restore InconsistentNaming
// ReSharper restore UnusedMember.Local
#endregion