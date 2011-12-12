namespace app
{
    public class Frame : IFrame
    {
        int score;
        IFrame previousFrame;
        readonly IDetermineIfAFrameIsComplete frameCompletionStrategy;

        int numberOfRolls;
        int numberOfBonusRolls;

        public Frame(IFrame previousFrame, IDetermineIfAFrameIsComplete frameCompletionStrategy)
        {
            this.previousFrame = previousFrame;
            this.frameCompletionStrategy = frameCompletionStrategy;
        }

        public bool Roll(int numberOfPinsKnockedDown)
        {
            score += numberOfPinsKnockedDown;
            previousFrame.NextFrameRoll(numberOfPinsKnockedDown);

            numberOfRolls++;
            if (score == 10)
            {
                numberOfBonusRolls = 3 - numberOfRolls;
            }

            return IsFrameComplete();
        }

        bool IsFrameComplete()
        {
            return frameCompletionStrategy.IsFrameComplete(numberOfRolls, score);
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