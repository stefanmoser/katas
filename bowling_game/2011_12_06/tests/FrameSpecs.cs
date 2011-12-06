using Machine.Specifications;
using app;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace tests
{
    [Subject(typeof (Frame))]
    public class FrameSpecs
    {
        public class Concern : Observes<Frame>
        {
            public class when_bowling_two_gutter_balls : Concern
            {
                Because of = () =>
                    {
                        sut.Roll(0);
                        sut.Roll(0);

                        result = sut.CalculateScore();
                    };

                It should_score_the_frame_as_zero = () =>
                    result.ShouldEqual(0);

                static int result;
            }

            public class when_bowling_two_singles : Concern
            {
                Because of = () =>
                    {
                        sut.Roll(1);
                        sut.Roll(1);

                        result = sut.CalculateScore();
                    };

                It should_score_the_frame_as_zero = () =>
                    result.ShouldEqual(2);

                static int result;
            }

            public class when_rolling_a_ball : Concern
            {
                Establish context = () =>
                    previousFrame = depends.on<IFrame>();

                Because of = () =>
                    sut.Roll(5);

                It should_tell_the_previous_frame_of_the_score = () =>
                    previousFrame.received(x => x.NextFrameRoll(5));
                
                static int result;
                static IFrame previousFrame;
            }
        }
    }
}