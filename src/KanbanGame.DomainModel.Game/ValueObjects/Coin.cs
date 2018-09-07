using KanbanGame.DomainModel.Game.Emuns;
using KanbanGame.DomainModel.Game.Interfaces;
using System;
using System.Collections.Generic;
using KanbanGame.DomainModel.Game.Services;

namespace KanbanGame.DomainModel.Game.ValueObjects
{
    public class Coin : ValueObject
    {
        public SideOfCoin Side { get; }

        public Coin(SideOfCoin side)
        {
            Side = side;
        }

        public static Coin Flip(IRandomService randomService = null)
        {
            randomService = randomService ?? new RandomService();
                
            var randomValue = randomService.GetRanodm(2);

            switch (randomValue)
            {
                case 0:
                    return new Coin(SideOfCoin.Heads);
                case 1:
                    return new Coin(SideOfCoin.Tails);
                default:
                    throw new InvalidOperationException("randomService returns wrong value");
            }
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Side;
        }
    }
}
