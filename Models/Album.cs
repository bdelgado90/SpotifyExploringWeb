using System.Diagnostics.CodeAnalysis;

namespace SpotifyExploringWeb.Models;

[ExcludeFromCodeCoverage]
public class Album
{
    public List<AlbumImage> Images { get; set; }
    public string Name { get; set; }
}

