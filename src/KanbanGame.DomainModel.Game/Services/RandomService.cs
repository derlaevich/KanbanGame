using KanbanGame.DomainModel.Game.Interfaces;
using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("KanbanGame.DomainModel.Game.Tests")]
namespace KanbanGame.DomainModel.Game.Services
{
    internal class RandomService : IRandomService
    {
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

        public int GetRanodm(int upperBound)
        {
            return _random.Next(upperBound);
        }
    }
}
