namespace app
{
    public class NullFrame : IFrame
    {
        public void NextFrameRoll(int numberOfPinsKnockedDown)
        {
        }

        public bool Roll(int numberOfPinsKnockedDown)
        {
            return false;
        }

        public int CalculateScore()
        {
            return 0;
        }
    }
}