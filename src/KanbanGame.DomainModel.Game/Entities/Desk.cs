using System;
using System.Collections.Generic;
using KanbanGame.Core;

namespace KanbanGame.DomainModel.Game.Entities
{
    public class Desk : Entity<Guid>
    {
        public Column Backlog { get; private set; }
        public Column ToDo { get; private set; }
        public Column Test { get; private set; }
        public Column Done { get; private set; }

        public Desk(List<Ticket> backlogTickets) : base(Guid.NewGuid())
        {
            Guard.ArgumentNotNullOrEmpty(nameof(backlogTickets), backlogTickets);
            
            Backlog = new Column(backlogTickets);
            ToDo = new Column();
            Test = new Column();
            Done = new Column();
        }

        public void MoveToNext(Ticket ticket)
        {
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
            source.Remove(ticket);
            destination.Add(ticket);
        }
    }
}