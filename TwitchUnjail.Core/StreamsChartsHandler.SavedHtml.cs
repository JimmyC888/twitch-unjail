using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TwitchUnjail.Core.Models;

namespace TwitchUnjail.Core {

    public static partial class StreamsChartsHandler {

        private static readonly Regex StreamsChartsSavedHtmlUrlRegex = new("<meta[^>]+property=['\"]og:url['\"][^>]+content=['\"]([^'\"]+)['\"]", RegexOptions.IgnoreCase);

        public static ValueTask<VodRecoveryInfo> RetrieveInfoFromSavedHtml(string filePath) {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath)) {
                throw new Exception("Saved streamscharts.com html file could not be found.");
            }

            var streamsChartsHtml = File.ReadAllText(filePath);
            var urlMatch = StreamsChartsSavedHtmlUrlRegex.Match(streamsChartsHtml);
            if (!urlMatch.Success || urlMatch.Groups.Count != 2) {
                throw new Exception("Saved streamscharts.com html file does not reference a valid stream url.");
            }

            var url = urlMatch.Groups[1].Value;

            try {
                return ValueTask.FromResult(ParseVodRecoveryInfo(url, streamsChartsHtml));
            } catch (Exception) {
                throw new Exception("Saved streamscharts.com html file is not a valid stream page or the page structure has recently changed and is no longer readable.");
            }
        }
    }
}
