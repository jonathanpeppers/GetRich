using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace GetRich
{
    public class GetRichClient
    {
        private const string Url = "http://thefluffingtonpost.com/rss";
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly Regex _regex = new Regex("src=\"([^\"]+)\"");

        public async Task<Picture[]> GetPictures()
        {
            var response = await _httpClient.GetAsync(Url);
            response.EnsureSuccessStatusCode();

            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                var doc = XDocument.Load(stream);

                var query = from i in doc.Descendants("item")
                            let title = i.Descendants("title").First()
                            let image = i.Descendants("description").First()
                            let match = _regex.Match(image.Value)
                            where match.Success
                            select new Picture
                            {
                                Title = title.Value,
                                Image = ImageSource.FromUri(new Uri(match.Groups[1].Value)),
                            };
                return query.ToArray();
            }
        }
    }
}
