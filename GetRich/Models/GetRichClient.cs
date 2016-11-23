using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Net.Http;

namespace GetRich
{
    public class GetRichClient
    {
        private const string Url = "http://thefluffingtonpost.com/rss";
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Picture[]> GetPictures()
        {
            var response = await _httpClient.GetAsync(Url);
            response.EnsureSuccessStatusCode();

            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                var doc = XDocument.Load(stream);

                var query = from i in doc.Descendants("item")
                            let title = i.Descendants("title").First()
                            let image = i.Descendants("img").First()
                            select new Picture
                            {
                                Title = title.Value,
                                Url = image.Value,
                            };
                return query.ToArray();
            }
        }
    }
}
