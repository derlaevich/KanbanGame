using System;
using System.Collections.Generic;
using KanbanGame.Core;

namespace KanbanGame.DomainModel.Game.Entities
{
    public class FeatureBanGame
    {
        private List<Player> _players;
        private int _numberOfRounds;

        public FeatureBanGame(List<Player> players, int numberOfRounds)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(players), players);

            var numberOfRoundsIsValid = numberOfRounds > 0;
            if (!numberOfRoundsIsValid)
            {
                    throw new ArgumentException("Argument must be greater than 0", nameof(numberOfRounds));
            }

            _players = players;
            _numberOfRounds = numberOfRounds;
        }        
    }
}