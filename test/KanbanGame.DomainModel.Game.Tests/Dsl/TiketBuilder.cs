using System;
using KanbanGame.DomainModel.Game.Entities;

namespace KanbanGame.DomainModel.Game.Tests.Dsl
{
    public class TicketBuilder
    {
        private Guid _ownerId = Guid.NewGuid();

        public Ticket Please()
        {
            return  new Ticket(_ownerId);
        }
    }
}