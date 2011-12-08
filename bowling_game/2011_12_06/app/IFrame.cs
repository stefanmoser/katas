namespace app
{
    public interface IFrame
    {
        void NextFrameRoll(int numberOfPinsKnockedDown);
        bool Roll(int numberOfPinsKnockedDown);
        int CalculateScore();
    }
}