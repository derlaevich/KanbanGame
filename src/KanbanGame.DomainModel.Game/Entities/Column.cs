using System;
using System.Collections.Generic;
using System.Linq;
using KanbanGame.Core;
using KanbanGame.DomainModel.Game.Emuns;

namespace KanbanGame.DomainModel.Game.Entities
{
    public class Column : Entity<Guid>
    {
        private readonly List<Ticket> _tickets;
        public IReadOnlyCollection<Ticket> Tickets => _tickets.AsReadOnly();

        public Column() : base (Guid.NewGuid())
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
            Guard.ArgumentNotNull(nameof(ticket), ticket);
            
            _tickets.Add(ticket);
        }

        public void Remove(Ticket ticket)
        {
            Guard.ArgumentNotNull(nameof(ticket), ticket);

            _tickets.Remove(ticket);
        }

        public bool Contains(Ticket ticket)
        {
            Guard.ArgumentNotNull(nameof(ticket), ticket);

            return _tickets.Contains(ticket);
        }

        public bool TryGetActiveTicket(Guid ownerId, out Ticket ticket)
        {
            ticket = _tickets.FirstOrDefault(t => t.OwnerId == ownerId && t.Status == TicketStatus.Active);

            return ticket != null;
        }
        
        public bool TryGetBlockTicket(Guid ownerId, out Ticket ticket)
        {
            ticket = _tickets.FirstOrDefault(t => t.OwnerId == ownerId && t.Status == TicketStatus.Block);

            return ticket != null;
        }

        public int Count()
        {
            return _tickets.Count;
        }
    }
}