using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortenerAPI.Models;
using ShortenerAPI.Services;

namespace ShortenerAPI.Controllers;

[ApiController]
[Route("shortener")]

public class ShortenedURLController : ControllerBase
{
    private readonly ShortenerContext _context;

    public ShortenedURLController(ShortenerContext context)
    {
        _context = context;
    }

    // GET: shortener/AvailableURLs
    // Returns all shortened URLs
    [HttpGet("availableurls")]
    public async Task<ActionResult<IEnumerable<ShortenedURL>>> GetShortenedURLs()
    {
        return await _context.ShortenedURLs.ToListAsync();
    }

    // GET: shortener/geturl/{id}
    // Returns all info about a shortened URL
    [HttpGet("geturl/{id}")]
    public async Task<ActionResult<ShortenedURL>> GetShortenedURL(string id)
    {
        var shortenedUrl = await _context.ShortenedURLs.FindAsync(id);
        if(shortenedUrl == null)
        {
            return NotFound();
        }
        return shortenedUrl;
    }

    // POST: shortener/shortenurl
    // Shortens a full URL
    [HttpPut("shortenurl")]
    public async Task<ActionResult<ShortenedURL>> PostShortenURL(FullURL fullURL)
    {
        var shortenedURL = ShortenerService.ShortenURL(fullURL.URL);
        _context.ShortenedURLs.Add(shortenedURL);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetShortenedURL), new { id = shortenedURL.ShortURLId }, shortenedURL);
    }

    // GET: shortener/{id}
    // Returns the full url associated with the shortened id
    [HttpGet("{id}")]
    public async Task<ActionResult<FullURL>> GetFullURL(string id)
    {
        var shortenedUrl = await _context.ShortenedURLs.FindAsync(id);

        if (shortenedUrl == null)
        {
            return NotFound();
        }
        var fullURL = new FullURL(shortenedUrl.OriginalURL);
        return fullURL;
    }

    // DELETE: shortener/clearall
    // Deletes all shortened URLs in the database
    // REMEMBER TO REMOVE
    [HttpDelete("clearall")]
    public async Task<ActionResult<FullURL>> DeleteAllURLs()
    {
        await _context.ShortenedURLs.ExecuteDeleteAsync();
        var fullURL = new FullURL("");
        return fullURL;
    }
}
