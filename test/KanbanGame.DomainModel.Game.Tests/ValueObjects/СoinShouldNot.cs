using KanbanGame.DomainModel.Game.Emuns;
using KanbanGame.DomainModel.Game.ValueObjects;
using Xunit;

namespace KanbanGame.DomainModel.Game.Tests.ValueObjects
{
    public class СoinShouldNot
    {
        [Fact]
        public void SameCoinsAreEqual_EvenIfDifferentReferences()
        {
            var coinFirst = new Coin(SideOfCoin.Tails);
            var coinSecond = new Coin(SideOfCoin.Heads);

            Assert.NotEqual(coinFirst, coinSecond);
        }
    }
}
