using System;
using KanbanGame.DomainModel.Game.Emuns;

namespace KanbanGame.DomainModel.Game.Entities
{
    public class Ticket : Entity<Guid>
    {
        public TicketStatus Status { get; private set; }
        public readonly Guid OwnerId;

        public Ticket(Guid ownerId) : base(Guid.NewGuid())
        {
            OwnerId = ownerId;
            Status = TicketStatus.Active;
        }

        public void Block()
        {
            Status = TicketStatus.Block;
        }

        public void Unblock()
        {
            Status = TicketStatus.Active;
        }
    }
}