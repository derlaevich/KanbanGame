using KanbanGame.DomainModel.Game.Emuns;
using KanbanGame.DomainModel.Game.Interfaces;
using System;
using System.Collections.Generic;

namespace KanbanGame.DomainModel.Game
{
    internal class Сoin : ValueObject<Сoin>
    {
        public SideOfCoin Side { get; private set; }

        private Сoin(SideOfCoin side)
        {
            Side = side;
        }

        public static Сoin Flip(IRandomService randomService)
        {
            //проверить на null
            var randomValue = randomService.GetRanodm(2);

            switch (randomValue)
            {
                case 0:
                    return new Сoin(SideOfCoin.Heads);
                case 1:
                    return new Сoin(SideOfCoin.Tails);
                default:
                    throw new InvalidOperationException("randomService returns wrong value");
            }
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            throw new NotImplementedException();
        }
    }
}
