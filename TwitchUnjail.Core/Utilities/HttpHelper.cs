using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TwitchUnjail.Core.Utilities {
    
    public static class HttpHelper {

        public const string DomainsUrl = "https://raw.githubusercontent.com/TwitchRecover/TwitchRecover/master/domains.txt";

        public const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.106 Safari/537.36";

        public static async Task<bool> IsUrlReachable(string url) {
            try {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
                client.DefaultRequestHeaders.Add("Client-ID", "kimne78kx3ncx6brgo4mv6wki5h1ko");
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public static async ValueTask<string[]> GetTwitchDomains()
        {
            // Switched to a manual list for internal/private use.
            // Previously fetched from: https://raw.githubusercontent.com/TwitchRecover/TwitchRecover/master/domains.txt
            /*
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            var response = await client.GetAsync(DomainsUrl);
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadAsStringAsync())
                .Split('\n')
                .Select(d => d.Trim())
                .ToArray();
            */

            return new[]
            {
                "https://vod-secure.twitch.tv",
                "https://vod-metro.twitch.tv",
                "https://vod-pop-secure.twitch.tv",
                "https://d2e2de1etea730.cloudfront.net",
                "https://dqrpb9wgowsf5.cloudfront.net",
                "https://ds0h3roq6wcgc.cloudfront.net",
                "https://d2nvs31859zcd8.cloudfront.net",
                "https://d2aba1wr3818hz.cloudfront.net",
                "https://d3c27h4odz752x.cloudfront.net",
                "https://dgeft87wbj63p.cloudfront.net",
                "https://d1m7jfoe9zdc1j.cloudfront.net",
                "https://d3vd9lfkzbru3h.cloudfront.net",
                "https://d2vjef5jvl6bfs.cloudfront.net",
                "https://d1ymi26ma8va5x.cloudfront.net",
                "https://d1mhjrowxxagfy.cloudfront.net",
                "https://ddacn6pr5v0tl.cloudfront.net",
                "https://d3aqoihi2n8ty8.cloudfront.net",
                "https://d3fi1amfgojobc.cloudfront.net"
            };

        }


        public static async ValueTask<string> GetHttp(string url) {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
