namespace app
{
    public class BowlingGame
    {
        readonly ICreateFrames _frameFactory;
        IBowlingFrame currentFrame;

        public BowlingGame(ICreateFrames frameFactory)
        {
            _frameFactory = frameFactory;
        }

        public void Roll(int numberOfPinsKnockedDown)
        {
            if (currentFrame == null)
            {
                currentFrame = _frameFactory.CreateFrame();
            }

            currentFrame.Roll(numberOfPinsKnockedDown);
        }
    }
}