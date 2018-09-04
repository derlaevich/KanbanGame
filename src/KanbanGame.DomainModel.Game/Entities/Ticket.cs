using System;
using KanbanGame.DomainModel.Game.Emuns;

namespace KanbanGame.DomainModel.Game.Entities
{
    public class Ticket : Entity<Guid>
    {
        public TiketStatus Status { get; private set; }
        public readonly Guid OwnerId;

        public Ticket(Guid ownerId) : base(Guid.NewGuid())
        {
            OwnerId = ownerId;
            Status = TiketStatus.Active;
        }

        public void Block()
        {
            Status = TiketStatus.Block;
        }

        public void Unblock()
        {
            Status = TiketStatus.Active;
        }
    }
}