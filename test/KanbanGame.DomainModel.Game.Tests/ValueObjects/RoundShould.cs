using KanbanGame.DomainModel.Game.Emuns;
using KanbanGame.DomainModel.Game.Entities;
using KanbanGame.DomainModel.Game.Tests.Dsl;
using KanbanGame.DomainModel.Game.ValueObjects;
using Moq;
using Xunit;

namespace KanbanGame.DomainModel.Game.Tests.ValueObjects
{
    public class RoundShould
    {
        [Fact]
        public void DoTailsActions_IfCoinSideIsTails()
        {
            var roundMock = Create
                .Round
                .WithCoin(new Coin(SideOfCoin.Tails))
                .PleaseMock();
            
            roundMock.Object.Play();

            roundMock.Verify(round => round.DoTailsActions(It.IsAny<Player>()), Times.Once());
        }
    }
}