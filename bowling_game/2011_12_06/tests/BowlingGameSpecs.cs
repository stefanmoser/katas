using Machine.Specifications;
using app;
using developwithpassion.specifications.rhinomocks;

namespace tests
{
    [Subject(typeof (BowlingGame))]
    public class BowlingGameSpecs
    {
        public class Concern : Observes<BowlingGame>
        {
            public class when_bowling_all_gutter_balls : Concern
            {
                Because of = () =>
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            sut.Roll(0);
                        }
                        result = sut.CalculateScore();
                    };

                It should_score_the_game_as_zero = () =>
                    result.ShouldEqual(0);

                static int result;
            }

            public class when_bowling_all_singles : Concern
            {
                Because of = () =>
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            sut.Roll(1);
                        }
                        result = sut.CalculateScore();
                    };

                It should_score_the_game_as_twenty = () =>
                    result.ShouldEqual(20);
                
                static int result;
            }

            public class when_bowling_a_spare : Concern
            {
                Because of = () =>
                    {
                        sut.Roll(5);
                        sut.Roll(5);
                        sut.Roll(2);

                        result = sut.CalculateScore();
                    };

                It should_include_the_bonus_roll_in_the_score = () =>
                    result.ShouldEqual(14);

                static int result;
            }
        }
    }
}