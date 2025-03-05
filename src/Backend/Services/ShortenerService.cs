using QRCoder;
using ShortenerAPI.Models;
using System.Reflection.Emit;

namespace ShortenerAPI.Services;

public class ShortenerService
{
    static public string GenerateURLExtension()
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[5];
        var random = new Random();

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        var finalString = new String(stringChars);
        return finalString;
    }

    static public ShortenedURL ShortenURL(string originalURL)
    {
        var shortenedURL = new ShortenedURL();
        shortenedURL.ShortURLId = GenerateURLExtension();
        shortenedURL.OriginalURL = originalURL;
        shortenedURL.Base64QRCode = GenerateQRCode(originalURL);
        return shortenedURL;
    }

    static public string GenerateQRCode(string url)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
        Base64QRCode qrCode = new Base64QRCode(qrCodeData);
        string qrCodeImageAsBase64 = qrCode.GetGraphic(20);
        return qrCodeImageAsBase64;
    }
}
