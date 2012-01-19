#region _

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

#endregion

using Machine.Specifications;
using Rhino.Mocks;
using app;

namespace tests
{
    [Subject(typeof(BowlingGame))]
    public class BowlingGameSpecs
    {
         public class when_the_first_ball_is_thrown
         {
             Establish context = () =>
                 {
                     _frameFactory = MockRepository.GenerateMock<ICreateFrames>();
                     _frame = MockRepository.GenerateMock<IBowlingFrame>();
                     _bowlingGame = new BowlingGame(_frameFactory);

                     _frameFactory.Expect(x => x.CreateFrame()).Return(_frame);
                 };

             Because of = () =>
                 _bowlingGame.Roll(_numberOfPinsKnockedDown);

             It should_start_a_new_frame = () =>
                 _frameFactory.AssertWasCalled(x => x.CreateFrame());

             It should_tell_the_frame_how_many_pins_were_knocked_down = () =>
                 _frame.AssertWasCalled(x => x.Roll(_numberOfPinsKnockedDown));

             static ICreateFrames _frameFactory;
             static BowlingGame _bowlingGame;
             static IBowlingFrame _frame;
             static int _numberOfPinsKnockedDown = 5;
         }

        public class when_the_second_ball_is_thrown
        {
            Establish context = () =>
                {
                    _frameFactory = MockRepository.GenerateMock<ICreateFrames>();
                    var frame = MockRepository.GenerateStub<IBowlingFrame>();
                    _frameFactory.Stub(x => x.CreateFrame()).Return(frame);
                    _bowlingGame = new BowlingGame(_frameFactory);
                    _bowlingGame.Roll(3);
                };

            Because of = () =>
                _bowlingGame.Roll(3);

            It should_not_start_another_frame = () =>
                _frameFactory.AssertWasCalled(x => x.CreateFrame(), o => o.Repeat.Once());

            static ICreateFrames _frameFactory;
            static BowlingGame _bowlingGame;
        }
    }
}

#region _

// ReSharper restore UnusedMember.Global
// ReSharper restore InconsistentNaming
// ReSharper restore UnusedMember.Local

#endregion