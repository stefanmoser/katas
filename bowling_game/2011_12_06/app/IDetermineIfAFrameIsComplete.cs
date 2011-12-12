namespace app
{
    public interface IDetermineIfAFrameIsComplete
    {
        bool IsFrameComplete(int numberOfRolls, int score);
    }
}