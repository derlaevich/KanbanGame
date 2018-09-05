using System;
using System.Collections.Generic;
using KanbanGame.DomainModel.Game.Entities;
using KanbanGame.DomainModel.Game.Tests.Dsl;
using Xunit;

namespace KanbanGame.DomainModel.Game.Tests.Entities
{
    public class DeskShould
    {
        [Fact]
        public void CreateInstanceWithIdWhichIsNotEqualEmptyGuid_WhenUsingDefaultConstructor()
        {
            var desk = Create
                .Desk
                .Please();
            
            Assert.NotEqual(Guid.Empty, desk.Id);
        }

        [Fact]
        public void ThrowException_WhenTicketsIsNull()
        {
            var desk = Create
                .Desk
                .WithTickets(null);
            
            var ex = Assert.Throws<ArgumentNullException>(() => desk.Please());

            Assert.Equal("backlogTickets", ex.ParamName);
        }

        [Fact]
        public void MoveToNextColumn_IfDeskContainsTicket()
        {
            var ticket = new Ticket(Guid.NewGuid());
            var desk = Create
                .Desk
                .WithTickets(new List<Ticket> {ticket})
                .Please();
            
            desk.MoveToNext(ticket);
            var contain = desk.ToDo.Contains(ticket);
            
            Assert.True(contain);
        }

        [Fact]
        public void ThrowException_IfTicketNotFound()
        {
            var ticket = new Ticket(Guid.NewGuid());
            var desk = Create
                .Desk
                .Please();
            
            var ex = Assert.Throws<InvalidOperationException>(() => desk.MoveToNext(ticket));

            Assert.Equal("Ticket not found", ex.Message);
        }
        
        [Fact]
        public void ThrowException_IfTicketIsInDoneColumn()
        {
            var ticket = new Ticket(Guid.NewGuid());
            var desk = Create
                .Desk
                .Please();
            
            var ex = Assert.Throws<InvalidOperationException>(() => desk.MoveToNext(ticket));

            Assert.Equal("The ticket is in the done column", ex.Message);
        }
    }
}