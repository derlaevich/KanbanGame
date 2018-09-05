using System;
using System.Collections.Generic;
using KanbanGame.DomainModel.Game.Entities;

namespace KanbanGame.DomainModel.Game.Tests.Dsl
{
    public class ColumnBuilder
    {
        private List<Ticket> _tickets = new List<Ticket>{new Ticket(ownerId: Guid.NewGuid())};

        public ColumnBuilder WithTickets(List<Ticket> tickets)
        {
            _tickets = tickets;

            return this;
        }
        
        public ColumnBuilder WithoutTickets()
        {
            _tickets = null;

            return this;
        }
        
        public Column Please()
        {
            return _tickets != null ? new Column(_tickets) : new Column();
        }
    }
}