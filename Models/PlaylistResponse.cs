using System.Diagnostics.CodeAnalysis;

namespace SpotifyExploringWeb.Models;

[ExcludeFromCodeCoverage]
public class PlaylistResponse
{
    public string Name { get; set; }
    public List<PlaylistImage> Images { get; set; }
    public PlaylistTracks Tracks { get; set; }
}
