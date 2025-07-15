using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects
{
    [TestClass]
    public class UrlTests
    {
        [DataRow("")]
        [DataRow("teste")]
        [DataRow(null)]
        [TestMethod]
        public void DeveLancarExcecaoParaUrlsInvalidas(string urlInvalida)
        {
            Assert.ThrowsException<InvalidUrlException>(() => new Url(urlInvalida), $"URL inválida esperada: {urlInvalida ?? "null"}");
        }

        [TestMethod]
        [DataRow("https://github.com/guilherme-alc")]
        [DataRow("http://localhost:5000/api/v1/customer")]
        [DataRow("http://127.0.0.1:8080/guilherme-alc")]
        public void DeveAceitarUrlsValidas(string urlValida)
        {
            var u = new Url(urlValida);
            Assert.AreEqual(urlValida, u.Address, $"Falha ao validar a URL: {urlValida}");
        }
    }
}
