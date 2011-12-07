namespace app
{
    public class Frame : IFrame
    {
        int score;
        IFrame previousFrame;

        int numberOfRolls;
        int numberOfBonusRolls;

        public Frame(IFrame previousFrame)
        {
            this.previousFrame = previousFrame;
        }

        public void Roll(int numberOfPinsKnockedDown)
        {
            score += numberOfPinsKnockedDown;
            previousFrame.NextFrameRoll(numberOfPinsKnockedDown);

            numberOfRolls++;
            if (score == 10)
            {
                numberOfBonusRolls = 3 - numberOfRolls;
            }
        }

        public void NextFrameRoll(int numberOfPinsKnockedDown)
        {
            if (numberOfBonusRolls > 0)
            {
                score += numberOfPinsKnockedDown;
                numberOfBonusRolls--;
            }
        }

        public int CalculateScore()
        {
            return score;
        }
    }
}