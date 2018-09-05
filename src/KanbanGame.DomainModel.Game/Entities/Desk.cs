using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KanbanGame.Core;

namespace KanbanGame.DomainModel.Game.Entities
{
    public class Desk : Entity<Guid>
    {
        private readonly List<Ticket> _backlog;
        public IReadOnlyCollection<Ticket> Backlog => _backlog.AsReadOnly();
        
        private readonly List<Ticket> _toDo;
        public IReadOnlyCollection<Ticket> ToDo => _toDo.AsReadOnly();
        
        private readonly List<Ticket> _test;
        public IReadOnlyCollection<Ticket> Test => _test.AsReadOnly();
        
        private readonly List<Ticket> _done;
        public IReadOnlyCollection<Ticket> Done => _done.AsReadOnly();

        public Desk(List<Ticket> tickets) : base(Guid.NewGuid())
        {
            Guard.ArgumentNotNullOrEmpty(nameof(tickets), tickets);
            
            _backlog = tickets;
        }
    }
}