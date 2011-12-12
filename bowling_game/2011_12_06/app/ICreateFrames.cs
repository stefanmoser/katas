namespace app
{
    public interface ICreateFrames
    {
        IFrame StartNewFrame(IFrame currentFrame, int frameCount);
    }
}