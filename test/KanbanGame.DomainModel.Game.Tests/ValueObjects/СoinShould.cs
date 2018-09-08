using KanbanGame.DomainModel.Game.Emuns;
using KanbanGame.DomainModel.Game.Tests.Dsl;
using KanbanGame.DomainModel.Game.ValueObjects;
using System;
using Xunit;

namespace KanbanGame.DomainModel.Game.Tests.ValueObjects
{
    public class СoinShould
    {
        [Fact]
        public void CreateNewCoinWithTailsSide_IfRandomServiceReturnsOne()
        {
            var randomService = Create
                .RandomService
                .WithResult(1)
                .Please();

            var coin = Coin.Flip(randomService);

            Assert.Equal(SideOfCoin.Tails, coin.Side);
        }
        
        [Fact]
        public void CreateNewCoinWithHeadsSide_IfRandomServiceReturnsOne()
        {
            var randomService = Create
                .RandomService
                .WithResult(0)
                .Please();

            var coin = Coin.Flip(randomService);

            Assert.Equal(SideOfCoin.Heads, coin.Side);
        }

        [Fact]
        public void ThrowException_IfRandomServiceReturnsMoreThenOne()
        {
            var randomService = Create
                .RandomService
                .WithResult(2)
                .Please();

            var ex = Assert.Throws<InvalidOperationException>(() => Coin.Flip(randomService));

            Assert.Equal("randomService returns wrong value", ex.Message);
        }

        [Fact]
        public void ThrowException_IfRandomServiceReturnsLessThenZero()
        {
            var randomService = Create
                .RandomService
                .WithResult(-1)
                .Please();

            var ex = Assert.Throws<InvalidOperationException>(() => Coin.Flip(randomService));

            Assert.Equal("randomService returns wrong value", ex.Message);
        }

        [Fact]
        public void SameCoinsAreEqual_EvenIfDifferentReferences()
        {
            var coinFirst = new Coin(SideOfCoin.Tails);
            var coinSecond = new Coin(SideOfCoin.Tails);

            Assert.Equal(coinFirst, coinSecond);
        }

        [Fact]
        public void CreateNewCoin_WhenCallFlip()
        {
            var randomService = Create
                .RandomService
                .Please(); ;
            var coin = Coin.Flip();

            var newCoin = Coin.Flip(randomService);

            Assert.NotSame(coin, newCoin);
        }
    }
}
