using System;
using KanbanGame.DomainModel.Game.Entities;

namespace KanbanGame.DomainModel.Game.Tests.Dsl
{
    public class TicketBuilder
    {
        private Guid _ownerId = Guid.NewGuid();

        public TicketBuilder WithOwnerId(Guid ownerId)
        {
            _ownerId = ownerId;

            return this;
        }

        public Ticket Please()
        {
            return  new Ticket(_ownerId);
        }
    }
}