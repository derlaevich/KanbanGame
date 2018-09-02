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
            Guard.ArgumentNotNullOrEmpty(nameof(players), players);

            _players = players;
        }
    }
}