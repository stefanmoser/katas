namespace app
{
    public class BowlingFrame : IBowlingFrame
    {
        const int MaximumNumberOfRolls = 2;
        const int MaxNumberOfPins  = 10;
        int numberOfRolls;
        int totalNumberOfPinsKnockedDown;

        public FrameStatus Roll(int numberOfPinsKnockedDown)
        {
            numberOfRolls++;
            totalNumberOfPinsKnockedDown += numberOfPinsKnockedDown;

            if (totalNumberOfPinsKnockedDown == MaxNumberOfPins)
            {
                return FrameStatus.Complete;
            }

            return numberOfRolls == MaximumNumberOfRolls ? FrameStatus.Complete : FrameStatus.Incomplete;
        }
    }
}