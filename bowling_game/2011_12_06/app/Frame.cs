namespace app
{
    public class Frame
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