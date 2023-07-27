using System.Net.Http.Headers;
using Newtonsoft.Json;
using SpotifyExploringWeb.Models;

namespace SpotifyExploringWeb.Services;

public class SpotifyService
{
    private readonly HttpClient httpClient;

    public SpotifyService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<string> GetAccessToken(string clientId, string clientSecret)
    {
        var requestBody = new Dictionary<string, string>
        {
            {"grant_type", Constants.GrantType},
            {"client_id", clientId},
            {"client_secret", clientSecret}
        };

        var requestContent = new FormUrlEncodedContent(requestBody);
        var response = await httpClient.PostAsync(Constants.TokenUrl, requestContent);
        var responseContent = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonConvert.DeserializeObject<SpotifyTokenResponse>(responseContent);

        return tokenResponse!.AccessToken;
    }

    public async Task<PlaylistResponse> GetPlaylist(string accessToken, string playlistId)
    {
        var playlistTracksUrl = string.Format(Constants.PlaylistTracksUrl, playlistId);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        var response = await httpClient.GetAsync(playlistTracksUrl);
        var responseContent = await response.Content.ReadAsStringAsync();
        var playlistResponse = JsonConvert.DeserializeObject<PlaylistResponse>(responseContent);

        return playlistResponse!;
    }
}
