using System;
using System.Collections.Generic;
using KanbanGame.Core;

namespace KanbanGame.DomainModel.Game.Entities
{
    public class Desk : Entity<Guid>
    {
        public Column Backlog { get; }
        public Column ToDo { get; }
        public Column Test { get; }
        public Column Done { get; }
        private int? _wipLimit { get; }

        public Desk(List<Ticket> backlogTickets, int? wipLimit = null) : base(Guid.NewGuid())
        {
            Guard.ArgumentNotNullOrEmpty(nameof(backlogTickets), backlogTickets);

            _wipLimit = wipLimit;
            Backlog = new Column(backlogTickets);
            ToDo = new Column();
            Test = new Column();
            Done = new Column();
        }

        public bool TryGetOpenAndActiveTicket(Guid ownerId, out Ticket ticket)
        {
            if (ToDo.TryGetActiveTicket(ownerId, out ticket))
            {
                return true;
            }
            
            if (Test.TryGetActiveTicket(ownerId, out ticket))
            {
                return true;
            }

            ticket = null;
            return false;
        }
        
        public bool TryGetOpenAndBlockTicket(Guid ownerId, out Ticket ticket)
        {
            if (ToDo.TryGetBlockTicket(ownerId, out ticket))
            {
                return true;
            }
            
            if (Test.TryGetBlockTicket(ownerId, out ticket))
            {
                return true;
            }

            ticket = null;
            return false;
        }

        public bool TryGetTicketFromBacklog(Guid ownerId, out Ticket ticket)
        {
            ticket = null;
            return Backlog.TryGetActiveTicket(ownerId, out ticket);
        }

        public void MoveToNextColumn(Ticket ticket)
        {
            Guard.ArgumentNotNull(nameof(ticket), ticket);
            
            if (Backlog.Contains(ticket))
            {
                Move(Backlog, ToDo, ticket);
                return;
            }
            
            if (ToDo.Contains(ticket))
            {
                Move(ToDo, Test, ticket);
                return;
            }
            
            if (Test.Contains(ticket))
            {
                Move(Test, Done, ticket);
                return;
            }
            
            if (Done.Contains(ticket))
            {
                throw new InvalidOperationException("The ticket is in the done column");
            }

            throw new InvalidOperationException("Ticket not found");
        }

        private void Move(Column source, Column destination, Ticket ticket)
        {
            var destinationColumnIsNotDone = destination != Done;
            var _wipLimitIsActive = _wipLimit.HasValue;
            if (destinationColumnIsNotDone && _wipLimitIsActive && destination.Count() >= _wipLimit)
            {
                throw new InvalidOperationException($"Maximum number of tickets in column: {_wipLimit}");     
            }

            source.Remove(ticket);
            destination.Add(ticket);
        }
    }
}