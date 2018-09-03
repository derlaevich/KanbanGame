using System;
using System.Collections.Generic;
using KanbanGame.DomainModel.Game.Entities;
using Xunit;

namespace KanbanGame.DomainModel.Game.Tests.Entities
{
    public class FeatureBanGameShouldNot
    {
        [Fact]
        public void CreateGameWithoutPlayers_WhenPlayersIsNull()
        {
            List<Player> players = null;
            
            var ex = Assert.Throws<ArgumentNullException>(() => new FeatureBanGame(players));

            Assert.Equal("players", ex.ParamName);
        }
        
        [Fact]
        public void CreateGameWithoutPlayers_WhenPassPlayerCollectionIsEmpty()
        {
            var playersCollection = new List<Player>();
            
            var ex = Assert.Throws<ArgumentException>(() => new FeatureBanGame(playersCollection));

            Assert.Equal("players", ex.ParamName);
        }
    }
}