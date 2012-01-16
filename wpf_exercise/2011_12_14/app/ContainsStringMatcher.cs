namespace app
{
    public class ContainsStringMatcher : IMatchStrings
    {
        readonly string substringToMatch;

        public ContainsStringMatcher(string substringToMatch)
        {
            this.substringToMatch = substringToMatch;
        }

        public bool Matches(string theString)
        {
            return theString.ToLower().Contains(substringToMatch.ToLower());
        }
    }
}