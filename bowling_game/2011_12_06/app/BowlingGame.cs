using System.Collections.Generic;
using System.Linq;

namespace app
{
    public class BowlingGame
    {
        IList<IFrame> frames;
        IFrame currentFrame;

        public BowlingGame()
        {
            frames = new List<IFrame>();
            currentFrame = new NullFrame();
            StartNewFrame(new RegularFrameCompletionStrategy());
        }

        public void Roll(int numberOfPinsKnockedDown)
        {
            bool isFrameComplete = currentFrame.Roll(numberOfPinsKnockedDown);
            if (isFrameComplete)
            {
                if (frames.Count == 9)
                {
                    StartNewFrame(new TenthFrameCompletionStrategy());
                }
                else
                {
                    StartNewFrame(new RegularFrameCompletionStrategy());
                }
            }
        }

        public int CalculateScore()
        {
            return frames.Sum(x => x.CalculateScore());
        }

        private void StartNewFrame(IDetermineIfAFrameIsComplete frameCompletionStrategy)
        {
            var nextFrame = new Frame(currentFrame, frameCompletionStrategy);
            frames.Add(nextFrame);
            currentFrame = nextFrame;
        }
    }
}