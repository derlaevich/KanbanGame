using System;
using System.Collections.Generic;
using KanbanGame.Core;

namespace KanbanGame.DomainModel.Game.Entities
{
    public class FeatureBanGame
    {
        private List<Player> _players;

        public FeatureBanGame(List<Player> players)
        {
            Guard.ArgumentNotNull(nameof(players), players);
            if (!players.GetEnumerator().MoveNext())
                throw new ArgumentException("Argument was empty", nameof(players));
            
            _players = players;
        }
    }
}