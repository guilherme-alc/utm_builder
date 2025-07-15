using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects
{
    [TestClass]
    public class UrlTests
    {

        [TestMethod]
        public void DeveRetornarExcecaoQuandoUrlInvalida()
        {
            try
            {
                new Url("teste");
                Assert.Fail();
            } 
            catch (InvalidUrlException ex)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void DeveRetornarExcecaoQuandoUrlVazia()
        {
            Assert.ThrowsException<InvalidUrlException>(() => new Url(""));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUrlException))]
        public void DeveRetornarExcecaoQuandoUrlNula()
        {
            new Url(null);
        }

        [TestMethod]
        public void NaoDeveRetornarExcecaoQuandoUrlValida()
        {
            var url = new Url("https://github.com/guilherme-alc");
            Assert.AreEqual("https://github.com/guilherme-alc", url.Address);
        }
    }
}
