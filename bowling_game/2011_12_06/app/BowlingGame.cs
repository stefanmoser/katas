using System.Collections.Generic;
using System.Linq;

namespace app
{
    public class BowlingGame
    {
        readonly FrameFactory frameFactory;

        IList<IFrame> frames;
        IFrame currentFrame;

        public BowlingGame(FrameFactory frameFactory)
        {
            this.frameFactory = frameFactory;
            frames = new List<IFrame>();
            currentFrame = new NullFrame();

            StartNewFrame();
        }

        public void Roll(int numberOfPinsKnockedDown)
        {
            bool isFrameComplete = currentFrame.Roll(numberOfPinsKnockedDown);
            if (isFrameComplete)
            {
                StartNewFrame();
            }
        }

        public int CalculateScore()
        {
            return frames.Sum(x => x.CalculateScore());
        }

        private void StartNewFrame()
        {
            var nextFrame = frameFactory.StartNewFrame(currentFrame, frames.Count);
            frames.Add(nextFrame);
            currentFrame = nextFrame;
        }
    }
}