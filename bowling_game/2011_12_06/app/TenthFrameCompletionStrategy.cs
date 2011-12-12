namespace app
{
    public class TenthFrameCompletionStrategy  : IDetermineIfAFrameIsComplete
    {
        int bonusRolls;

        public bool IsFrameComplete(int numberOfRolls, int score)
        {
            if (numberOfRolls == 2 && score < 10)
            {
                return true;
            }

            if (bonusRolls > 0)
            {
                bonusRolls--;
                return false;
            }

            if (score == 10)
            {
                bonusRolls = 3 - numberOfRolls;
            }

            return false;
        }
    }
}