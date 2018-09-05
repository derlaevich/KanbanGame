using System;
using System.Collections.Generic;
using KanbanGame.DomainModel.Game.Entities;

namespace KanbanGame.DomainModel.Game.Tests.Dsl
{
    public class DeskBuilder
    {
        private List<Ticket> _tickets = new List<Ticket>(){new Ticket(ownerId: Guid.NewGuid())};

        public DeskBuilder WithTickets(List<Ticket> tickets)
        {
            _tickets = tickets;

            return this;
        }

        public Desk Please()
        {
            return new Desk(_tickets);
        }
    }
}