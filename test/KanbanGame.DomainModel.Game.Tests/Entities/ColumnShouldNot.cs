using System;
using KanbanGame.DomainModel.Game.Entities;
using KanbanGame.DomainModel.Game.Tests.Dsl;
using Xunit;

namespace KanbanGame.DomainModel.Game.Tests.Entities
{
    public class ColumnShouldNot
    {
        [Fact]
        public void ContainsTicket_IfTicketWasAdded()
        {
            var column = Create
                .Column
                .Please();
            var ticket = new Ticket(Guid.NewGuid());
            
            var result = column.Contains(ticket);
            
            Assert.False(result);
        }
    }
}