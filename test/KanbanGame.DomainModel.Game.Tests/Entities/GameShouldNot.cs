using System;
using System.Collections.Generic;
using KanbanGame.DomainModel.Game.Entities;
using Xunit;

namespace KanbanGame.DomainModel.Game.Tests.Entities
{
    public class GameShouldNot
    {
        [Fact]
        public void CreateGameWithoutPlayers_WhenPlayersIsNull()
        {
            List<Player> players = null;
            
            var ex = Assert.Throws<ArgumentNullException>(() => new FeatureBanGame(players));

            Assert.Equal("players", ex.ParamName);
        }
        
        [Fact]
        public void CreateGameWithoutPlayers_WhenPlayersIsEmpty()
        {
            var players = new List<Player>();
            
            var ex = Assert.Throws<ArgumentException>(() => new FeatureBanGame(players));

            Assert.Equal("players", ex.ParamName);
        }
    }
}