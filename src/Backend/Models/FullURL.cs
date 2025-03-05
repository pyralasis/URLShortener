namespace ShortenerAPI.Models
{
    public class FullURL
    {
        public FullURL(string uRL)
        {
            URL = uRL;
        }

        public string URL { get; set; }
    }
}
