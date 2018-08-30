using KanbanGame.DomainModel.Game.Emuns;
using KanbanGame.DomainModel.Game.Interfaces;
using System;
using System.Collections.Generic;

namespace KanbanGame.DomainModel.Game.ValueObjects
{
    public class Coin : ValueObject
    {
        public SideOfCoin Side { get; private set; }

        public Coin(SideOfCoin side)
        {
            Side = side;
        }

        public Coin() : this(SideOfCoin.Tails) { }

        public Coin Flip(IRandomService randomService)
        {
            //TODO: выделить в отдельный класс
            if (randomService == null)
            {
                throw new ArgumentNullException(nameof(randomService));
            }

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
