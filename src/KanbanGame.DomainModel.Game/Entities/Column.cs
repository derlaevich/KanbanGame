using System;
using System.Collections.Generic;
using KanbanGame.Core;

namespace KanbanGame.DomainModel.Game.Entities
{
    public class Column : Entity<Guid>
    {
        private readonly List<Ticket> _tickets;
        public IReadOnlyCollection<Ticket> Tickets => _tickets.AsReadOnly();

        public Column():base (Guid.NewGuid())
        {
            _tickets = new List<Ticket>();
        }

        public Column(List<Ticket> tickets):this()
        {
            Guard.ArgumentNotNullOrEmpty(nameof(tickets), tickets);
            
            _tickets = tickets;
        }

        public void Add(Ticket ticket)
        {
            _tickets.Add(ticket);
        }

        public void Remove(Ticket ticket)
        {
            _tickets.Remove(ticket);
        }
    }
}