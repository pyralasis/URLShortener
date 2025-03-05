using Microsoft.EntityFrameworkCore;
using QRCoder;
using System.ComponentModel.DataAnnotations;

namespace ShortenerAPI.Models
{
    public class ShortenedURL
    {
        public string ShortURLId { get; set; }
        public string OriginalURL { get; set; }
        public string Base64QRCode { get; set; }
    }
}


