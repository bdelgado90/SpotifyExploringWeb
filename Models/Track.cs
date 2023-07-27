using System.Diagnostics.CodeAnalysis;

namespace SpotifyExploringWeb.Models;

[ExcludeFromCodeCoverage]
public class Track
{
    public string Name { get; set; }
    public Album Album { get; set; }
}
