using System;

namespace KanbanGame.DomainModel.Game.Entities
{
    public class Player : Entity<Guid>
    {
        public Player() : base(Guid.NewGuid())
        {}
    }
}