namespace app
{
    public class ContainsStringMatcher : IMatchStrings
    {
        readonly string _substringToMatch;

        public ContainsStringMatcher(string substringToMatch)
        {
            _substringToMatch = substringToMatch;
        }

        public bool Matches(string theString)
        {
            return theString.Contains(_substringToMatch);
        }
    }
}