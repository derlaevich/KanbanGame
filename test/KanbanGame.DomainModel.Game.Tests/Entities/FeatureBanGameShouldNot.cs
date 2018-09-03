using System;
using System.Collections.Generic;
using KanbanGame.DomainModel.Game.Entities;
using KanbanGame.DomainModel.Game.Tests.Dsl;
using Xunit;

namespace KanbanGame.DomainModel.Game.Tests.Entities
{
    public class FeatureBanGameShouldNot
    {
        [Fact]
        public void CreateGameWithoutPlayers_WhenPlayersIsNull()
        {
            var gameBuilder = Create
                .FeatureBanGame
                .WithPlayers(null);
            
            var ex = Assert.Throws<ArgumentNullException>(() => gameBuilder.Please());

            Assert.Equal("players", ex.ParamName);
        }
        
        [Fact]
        public void CreateGameWithoutPlayers_WhenPassPlayerCollectionIsEmpty()
        {
            var gameBuilder = Create
                .FeatureBanGame
                .WithPlayers(new List<Player>());
            
            var ex = Assert.Throws<ArgumentException>(() => gameBuilder.Please());

            Assert.Equal("players", ex.ParamName);
        }
        
        [Fact]
        public void CreateGame_IfNumberOfRoundsLessThanOne()
        {
            var gameBuilder = Create
                .FeatureBanGame
                .WithNumberOfRounds(0);
            
            var ex = Assert.Throws<ArgumentException>(() => gameBuilder.Please());

            Assert.Equal("numberOfRounds", ex.ParamName);
            Assert.Contains("Argument must be greater than 0", ex.Message);
        }
    }
}