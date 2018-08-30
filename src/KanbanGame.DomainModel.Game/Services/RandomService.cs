using KanbanGame.DomainModel.Game.Interfaces;
using System;

namespace KanbanGame.DomainModel.Game.Services
{
    public class RandomService : IRandomService
    {
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

        public int GetRanodm(int upperBound)
        {
            return _random.Next(upperBound);
        }
    }
}
