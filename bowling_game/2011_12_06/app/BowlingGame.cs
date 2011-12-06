namespace app
{
    public class BowlingGame
    {
        int score;

        public void Roll(int numberOfPinsKnockedDown)
        {
            score += numberOfPinsKnockedDown;
        }

        public int CalculateScore()
        {
            return score;
        }
    }
}