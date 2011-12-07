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

            public class after_bowling_a_complete_game : Concern
            {
                Because of = () =>
                    {
                        sut.Roll(1);
                        sut.Roll(4);

                        sut.Roll(4);
                        sut.Roll(5);

                        sut.Roll(6);
                        sut.Roll(4);

                        sut.Roll(5);
                        sut.Roll(5);

                        sut.Roll(10);

                        sut.Roll(0);
                        sut.Roll(1);

                        sut.Roll(7);
                        sut.Roll(3);

                        sut.Roll(6);
                        sut.Roll(3);

                        sut.Roll(10);

                        sut.Roll(2);
                        sut.Roll(8);
                        sut.Roll(6);

                        result = sut.CalculateScore();
                    };

                It should_calculate_the_correct_score = () =>
                    result.ShouldEqual(133);

                static int result;
            }
        }
    }
}