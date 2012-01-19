using Machine.Specifications;
using app;

namespace tests
{
    [Subject(typeof(BowlingFrame))]
    public class BowlingFrameSpecs
    {
         public class when_the_first_ball_is_thrown
         {
             Establish context = () =>
                 _frame = new BowlingFrame();

             Because of = () =>
                 _frameStatus = _frame.Roll(4);

             It should_keep_the_frame_active = () =>
                 _frameStatus.ShouldEqual(FrameStatus.Incomplete);

             static FrameStatus _frameStatus;
             static BowlingFrame _frame;
         }

        public class when_two_balls_are_thrown
        {
            Establish context = () =>
                _frame = new BowlingFrame();

            Because of = () =>
                {
                    _frame.Roll(3);
                    _frameStatus = _frame.Roll(2);
                };


            It should_report_the_frame_as_complete = () =>
                _frameStatus.ShouldEqual(FrameStatus.Complete);

            static FrameStatus _frameStatus;
            static BowlingFrame _frame;
        }

        public class when_a_strike_is_thrown
        {
            Establish context = () =>
                _frame = new BowlingFrame();

            Because of = () =>
            {
                _frameStatus = _frame.Roll(10);
            };

            It should_report_the_frame_as_complete = () =>
                _frameStatus.ShouldEqual(FrameStatus.Complete);

            static FrameStatus _frameStatus;
            static BowlingFrame _frame;
        }
    }
}