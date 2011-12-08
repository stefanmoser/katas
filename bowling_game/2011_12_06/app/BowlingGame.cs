using System;
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
            StartNewFrame();
        }

        public void Roll(int numberOfPinsKnockedDown)
        {
            bool isFrameComplete = currentFrame.Roll(numberOfPinsKnockedDown);
            if (isFrameComplete)
            {
                if (frames.Count == 9)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    StartNewFrame();
                }
            }
        }

        public int CalculateScore()
        {
            return frames.Sum(x => x.CalculateScore());
        }

        private void StartNewFrame()
        {
            var nextFrame = new Frame(currentFrame);
            frames.Add(nextFrame);
            currentFrame = nextFrame;
        }
    }
}