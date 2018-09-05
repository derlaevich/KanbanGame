using System;
using KanbanGame.DomainModel.Game.Emuns;
using KanbanGame.DomainModel.Game.Tests.Dsl;
using Xunit;

namespace KanbanGame.DomainModel.Game.Tests.Entities
{
    public class TicketShould
    {
        [Fact]
        public void CreateInstanceWithIdWhichIsNotEqualEmptyGuid_WhenUsingDefaultConstructor()
        {
            var ticket = Create
                .Ticket
                .Please();
            
            Assert.NotEqual(Guid.Empty, ticket.Id);
        }

        [Fact]
        public void CreateInstanceWithActiveStatus()
        {
            var ticket = Create
                .Ticket
                .Please();
            
            Assert.Equal(TicketStatus.Active, ticket.Status);
        }

        [Fact]
        public void ChangeStatusToBlock_WhenCallBlock()
        {
            var ticket = Create
                .Ticket
                .Please();
            
            ticket.Block();
            
            Assert.Equal(TicketStatus.Block, ticket.Status);
        }

        [Fact]
        public void ChangeStatusToActive_WhenCallUnblock()
        {
            var ticket = Create
                .Ticket
                .Please();
            
            ticket.Unblock();
            
            Assert.Equal(TicketStatus.Active, ticket.Status);
        }
    }
}