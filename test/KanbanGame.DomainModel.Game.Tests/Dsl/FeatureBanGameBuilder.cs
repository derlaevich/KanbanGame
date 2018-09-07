using System.Collections.Generic;
using KanbanGame.DomainModel.Game.Entities;

namespace KanbanGame.DomainModel.Game.Tests.Dsl
{
    public class FeatureBanGameBuilder
    {
        private List<Player> _players = new List<Player>() {new Player()};
        private int _numberOfRounds = 5;

        public FeatureBanGameBuilder WithPlayers(List<Player> players)
        {
            _players = players;

            return this;
        }
        
        public FeatureBanGameBuilder WithNumberOfRounds(int numberOfRounds)
        {
            _numberOfRounds = numberOfRounds;

            return this;
        }

        public FeatureBanGame Please()
        {
            return new FeatureBanGame(_players, null, _numberOfRounds);
        }
    }
}