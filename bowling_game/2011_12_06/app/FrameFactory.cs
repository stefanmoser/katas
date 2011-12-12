namespace app
{
    public class FrameFactory : ICreateFrames
    {
        public IFrame StartNewFrame(IFrame currentFrame, int frameCount)
        {
            if (frameCount == 9)
            {
                return new Frame(currentFrame, new TenthFrameCompletionStrategy());
            }
            else
            {
                return new Frame(currentFrame, new RegularFrameCompletionStrategy());
            }
        }
    }
}