using System;
using System.Collections.Generic;
using KanbanGame.DomainModel.Game.Entities;
using KanbanGame.DomainModel.Game.Tests.Dsl;
using Xunit;

namespace KanbanGame.DomainModel.Game.Tests.Entities
{
    public class ColumnShould
    {
        [Fact]
        public void CreateInstanceWithIdWhichIsNotEqualEmptyGuid()
        {
            var ticket = Create
                .Column
                .Please();
            
            Assert.NotEqual(Guid.Empty, ticket.Id);
        }
        
        [Fact]
        public void ThrowException_WhenTicketsIsEmpty()
        {
            var ticketBuilder = Create
                .Column
                .WithTickets(new List<Ticket>());
            
            var ex = Assert.Throws<ArgumentException>(() => ticketBuilder.Please());

            Assert.Equal("tickets", ex.ParamName);
            Assert.Contains("Argument was empty", ex.Message);
        }

        [Fact]
        public void AddTicket_WhenCallAdd()
        {
            var column = Create
                .Column
                .WithoutTickets()
                .Please();
            
            column.Add(new Ticket(Guid.NewGuid()));
            
            Assert.Equal(1, column.Tickets.Count);
        }
        
        [Fact]
        public void RemoveTicket_WhenCallRemove()
        {
            var ticket = new Ticket(Guid.NewGuid());
            var column = Create
                .Column
                .WithTicket(ticket)
                .Please();
            
            column.Remove(ticket);
            
            Assert.Equal(0, column.Tickets.Count);
        }
        
        [Fact]
        public void ContainsTicket_IfTicketWasAdded()
        {
            var column = Create
                .Column
                .WithoutTickets()
                .Please();
            var ticket = new Ticket(Guid.NewGuid());
            column.Add(ticket);
            
            var result = column.Contains(ticket);
            
            Assert.True(result);
        }
        
        [Fact]
        public void MoveTicketToNextColumn()
        {
            var column = Create
                .Column
                .WithoutTickets()
                .Please();
            var ticket = new Ticket(Guid.NewGuid());
            column.Add(ticket);
            
            var result = column.Contains(ticket);
            
            Assert.True(result);
        }

        [Fact]
        public void ReturnTicket_IfContains()
        {
            var ownerId = Guid.NewGuid();
            var ticket = Create
                .Ticket
                .WithOwnerId(ownerId)
                .Please();
            var column = Create
                .Column
                .WithTicket(ticket)
                .Please();

            var result = column.TryGetActiveTicket(ownerId, out var foundTicket);
            
            Assert.True(result);
            Assert.Equal(ticket, foundTicket);
        }
    }
}