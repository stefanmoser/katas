namespace app
{
    public class RegularFrameCompletionStrategy : IDetermineIfAFrameIsComplete
    {
        public bool IsFrameComplete(int numberOfRolls, int score)
        {
            return numberOfRolls == 2 || score == 10;
        }
    }
}