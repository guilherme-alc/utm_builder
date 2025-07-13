using UtmBuilder.Core.ValueObjects;

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
    }
}
