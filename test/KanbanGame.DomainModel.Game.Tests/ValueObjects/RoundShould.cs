using System.Collections.Generic;
using System.Globalization;
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
        
        [Fact]
        public void DoHeadsActions_IfCoinSideIsHeads()
        {
            var roundMock = Create
                .Round
                .WithCoin(new Coin(SideOfCoin.Heads))
                .PleaseMock();
            
            roundMock.Object.Play();

            roundMock.Verify(round => round.DoHeadsActions(It.IsAny<Player>()), Times.Once());
        }

        [Fact]
        public void MoveToNextColumn_IfCoinSideIsTails()
        {
            var player = new Player();
            var ticket = Create
                .Ticket
                .WithOwnerId(player.Id)
                .Please();
            var desk = Create
                .Desk
                .WithTickets(new List<Ticket>{ ticket })
                .Please();
            var round = Create
                .Round
                .WithDesk(desk)
                .Please();
            desk.MoveToNextColumn(ticket);

            round.DoTailsActions(player);
            
            Assert.True(desk.Test.Contains(ticket));
        }
        
        [Fact]
        public void UnblockTicket_IfCoinSideIsTails()
        {
            var player = new Player();
            var ticket = Create
                .Ticket
                .WithOwnerId(player.Id)
                .Please();
            var desk = Create
                .Desk
                .WithTickets(new List<Ticket>{ ticket })
                .Please();
            var round = Create
                .Round
                .WithDesk(desk)
                .Please();
            desk.MoveToNextColumn(ticket);
            ticket.Block();

            round.DoTailsActions(player);
            
            Assert.Equal(TicketStatus.Active, ticket.Status);
        }
        
        [Fact]
        public void OpenTicket_IfCoinSideIsTails()
        {
            var player = new Player();
            var ticket = Create
                .Ticket
                .WithOwnerId(player.Id)
                .Please();
            var desk = Create
                .Desk
                .WithTickets(new List<Ticket>{ ticket })
                .Please();
            var round = Create
                .Round
                .WithDesk(desk)
                .Please();

            round.DoTailsActions(player);
            
            Assert.True(desk.ToDo.Contains(ticket));
        }
    }
}