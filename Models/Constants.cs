using System.Diagnostics.CodeAnalysis;

namespace SpotifyExploringWeb.Models;

[ExcludeFromCodeCoverage]
public static class Constants
{
    public const string TokenUrl = "https://accounts.spotify.com/api/token";
    public const string GrantType = "client_credentials";
    public const string PlaylistTracksUrl = "https://api.spotify.com/v1/playlists/{0}?fields=name,images,tracks.items(track(name,album(name,images)))";
    public const string PlaylistId = "37i9dQZF1EVJSvZp5AOML2";
}
