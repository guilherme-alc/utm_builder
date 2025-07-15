using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests
{
    [TestClass]
    public class UtmTests
    {
        private readonly Url _url = new ("https://github.com/guilherme-alc/");
        private readonly Campaign _campaign = new ("src", "med", "nme", "id", "trm", "ctnt");
        private const string _result = "https://github.com/guilherme-alc/?" +
                "utm_source=src&" +
                "utm_medium=med&" +
                "utm_campaign=nme&" +
                "utm_id=id&" +
                "utm_term=trm&" +
                "utm_content=ctnt";

        [TestMethod]
        public void DeveRetornarUrlDaUtm()
        {
            var utm = new Utm(_url, _campaign);
            Assert.AreEqual(_result, utm.ToString());
            Assert.AreEqual(_result, (string) utm);
        }

        [TestMethod]
        public void DeveRetornarUmUtmDaUrl()
        {
            Utm utm = _result;
            Assert.AreEqual("https://github.com/guilherme-alc/", utm.Url.Address);
            Assert.AreEqual("src", utm.Campaign.Source);
            Assert.AreEqual("med", utm.Campaign.Medium);
            Assert.AreEqual("nme", utm.Campaign.Name);
            Assert.AreEqual("id", utm.Campaign.Id);
            Assert.AreEqual("trm", utm.Campaign.Term);
            Assert.AreEqual("ctnt", utm.Campaign.Content);
        }
    }
}
