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
                        isFrameComplete = sut.Roll(1);

                        result = sut.CalculateScore();
                    };

                It should_score_the_frame_as_zero = () =>
                    result.ShouldEqual(2);

                It should_report_the_frame_as_complete = () =>
                    isFrameComplete.ShouldBeTrue();

                static int result;
                static bool isFrameComplete;
            }

            public class when_rolling_a_ball : Concern
            {
                Establish context = () =>
                    previousFrame = depends.on<IFrame>();

                Because of = () =>
                    result = sut.Roll(5);

                It should_tell_the_previous_frame_of_the_score = () =>
                    previousFrame.received(x => x.NextFrameRoll(5));

                It should_report_the_frame_as_incomplete = () =>
                    result.ShouldBeFalse();
                
                static bool result;
                static IFrame previousFrame;
            }

            public class after_bowling_a_strike : Concern
            {
                Because of = () =>
                    {
                        isFrameComplete = sut.Roll(10);
                        sut.NextFrameRoll(4);
                        sut.NextFrameRoll(3);

                        result = sut.CalculateScore();
                    };

                It should_add_the_next_two_rolls_as_the_bonus_score = () =>
                    result.ShouldEqual(17);

                It should_report_the_frame_as_complete = () =>
                    isFrameComplete.ShouldBeTrue();

                static int result;
                static bool isFrameComplete;
            }

            public class after_bowling_a_spare : Concern
            {
                Because of = () =>
                    {
                        sut.Roll(6);
                        sut.Roll(4);
                        sut.NextFrameRoll(4);
                        sut.NextFrameRoll(3);

                        result = sut.CalculateScore();
                    };

                It should_add_the_next_roll_as_the_bonus_score = () =>
                    result.ShouldEqual(14);

                static int result;
            }
        }
    }
}