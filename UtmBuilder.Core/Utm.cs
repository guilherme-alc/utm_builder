using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core
{
    public class Utm
    {
        public Utm(Url url, Campaign campaign)
        {
            Url = url;
            Campaign = campaign;
        }
        /// <summary>
        /// URL (Website link)
        /// </summary>
        public Url Url { get; init; }
        /// <summary>
        /// Campaign details
        /// </summary>
        public Campaign Campaign { get; init; }

        public override string ToString()
        {
            var segments = new List<string>();
            segments.AddIfNotNull("utm_source", Campaign.Source);
            segments.AddIfNotNull("utm_medium", Campaign.Medium);
            segments.AddIfNotNull("utm_campaing", Campaign.Name);
            segments.AddIfNotNull("utm_id", Campaign.Id);
            segments.AddIfNotNull("utm_term", Campaign.Term);
            segments.AddIfNotNull("utm_content", Campaign.Content);
            return $"{Url.Address}?{string.Join("&", segments)}";
        }

        public static implicit operator string(Utm utm) => utm.ToString();

        public static implicit operator Utm(string stringUrl)
        {
            if (string.IsNullOrEmpty(stringUrl))
                throw new InvalidUrlException();

            var segments = stringUrl.Split("?");

            if(segments.Length == 1)
                throw new InvalidUrlException("Url sem segmentos fornecido");

            Url url = new (segments[0]);

            var pars = segments[1].Split("&");
            var source = pars.Where(x => x.StartsWith("utm_source")).FirstOrDefault("").Split("=")[1];
            var medium = pars.Where(x => x.StartsWith("utm_medium")).FirstOrDefault("").Split("=")[1];
            var name = pars.Where(x => x.StartsWith("utm_campaign")).FirstOrDefault("").Split("=")[1];
            var id = pars.Where(x => x.StartsWith("utm_id")).FirstOrDefault("").Split("=")[1];
            var term = pars.Where(x => x.StartsWith("utm_term")).FirstOrDefault("").Split("=")[1];
            var content = pars.Where(x => x.StartsWith("utm_content")).FirstOrDefault("").Split("=")[1];

            Campaign campaing = new(source, medium, name, id, term, content);

            return new Utm(url, campaing);
        }
    }
}
