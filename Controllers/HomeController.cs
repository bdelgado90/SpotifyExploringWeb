using Microsoft.AspNetCore.Mvc;
using SpotifyExploringWeb.Models;
using SpotifyExploringWeb.Services;

namespace SpotifyExploringWeb.Controllers;

public class HomeController : Controller
{
    private readonly SpotifyService spotifyService;
    private readonly IConfiguration configuration;

    public HomeController(SpotifyService spotifyService, IConfiguration configuration)
    {
        this.spotifyService = spotifyService;
        this.configuration = configuration;
    }

    public async Task<IActionResult> Index()
    {
        // Read Spotify API credentials from the KeyVault
        var clientId = configuration["SpotifyClientId"];
        var clientSecret = configuration["SpotifyClientSecret"];

        // Get the access token
        var accessToken = await spotifyService.GetAccessToken(clientId!, clientSecret!);

        // Get playlist details and tracks
        var playlist = await spotifyService.GetPlaylist(accessToken, Constants.PlaylistId);

        return View(playlist);
    }
}
