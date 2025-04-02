namespace TeachLink_BackEnd.Core.Helpers
{
    public static class CreateDictionary
    {
        public static Dictionary<string, string> CreateDictionaryToken(string token)
        {
            return new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };
        }
    }
}
