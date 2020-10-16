using NUnit.Framework;

namespace Bimaru.SWA.InClass.Test
{
    public class BoardTests
    {
        [Test]
        public void ParseBoardTest()
        {
            Assert.DoesNotThrow(() => {
                RawBoardProvider provider = new RawBoardProvider();
                Board board = new Board(provider.GetBoardRaw());
            });
        }
    }
}