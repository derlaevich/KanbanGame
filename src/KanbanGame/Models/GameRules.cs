using System;
using System.Collections.Generic;

namespace KanbanGame.Models
{
    public class GameRules
    {
        private static readonly Random _random = new Random(Guid.NewGuid().GetHashCode());
        private static readonly List<int> NumberOfPlayersList = new List<int> { 3, 5, 10 };
        private static readonly List<int> NumberOfRoundsList = new List<int> { 15, 20 };
        private static readonly List<int?> WipLimitList = new List<int?> { null, 1, 2, 3, 4, 5 };

        public int NumberOfPlayers { get; }
        public int NumberOfRounds { get; }
        public int? WipLimit { get; }

        private GameRules(int numberOfPlayers, int numberOfRounds, int? wipLimit)
        {
            NumberOfPlayers = numberOfPlayers;
            NumberOfRounds = numberOfRounds;
            WipLimit = wipLimit;
        }

        public static GameRules Create()
        {
            var numberOfPlayers = GetRandomItem(NumberOfPlayersList);
            var numberOfRounds = GetRandomItem(NumberOfRoundsList);
            var wipLimit = GetRandomItem(WipLimitList);

            return new GameRules(numberOfPlayers, numberOfRounds, wipLimit);
        }

        private static T GetRandomItem<T>(List<T> items)
        {
            var index = _random.Next(items.Count);
            return items[index];
        }
    }
}