using KanbanGame.DomainModel.Game.Emuns;
using KanbanGame.DomainModel.Game.Interfaces;
using Moq;
using Xunit;

namespace KanbanGame.DomainModel.Game.Tests
{
    public class СoinShould
    {
        [Fact]
        public void CreateNewCoinWithHeadSide_IfRandomServiceReturnZero()
        {
            var randomServiceMock = new Mock<IRandomService>();
            randomServiceMock
                .Setup(rs => rs.GetRanodm(It.IsAny<int>()))
                .Returns(0);

            var coin = Сoin.Flip(randomServiceMock.Object);

            Assert.Equal(SideOfCoin.Heads, coin.Side);
        }

        [Fact]
        public void CreateNewCoinWithTailsSide_IfRandomServiceReturnOne()
        {
            var randomServiceMock = new Mock<IRandomService>();
            randomServiceMock
                .Setup(rs => rs.GetRanodm(It.IsAny<int>()))
                .Returns(1);

            var coin = Сoin.Flip(randomServiceMock.Object);

            Assert.Equal(SideOfCoin.Tails, coin.Side);
        }
    }
}
