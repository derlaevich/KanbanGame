using System;
using System.Linq;
using KanbanGame.DomainModel.Game.Tests.Dsl;
using Xunit;

namespace KanbanGame.DomainModel.Game.Tests.Entities
{
    public class FeatureBanGameShould
    {
        [Fact]
        public void PlaySetupNumberOfRounds()
        {
            var game = Create
                .FeatureBanGame
                .WithNumberOfRounds(5)
                .Please();

            game.StartGame();
            //var playedRounds = game.MoveNextRounds().Count();
            var playedRounds = 0;
            while (game.MoveNextRounds())
            {
                playedRounds++;
            }
            
            Assert.Equal(5, playedRounds);
        }

        [Fact]
        public void ThrowException_WhenGetNextRoundButGameIsStopped()
        {
            var game = Create
                .FeatureBanGame
                .Please();
            
            var ex = Assert.Throws<InvalidOperationException>(() => game.MoveNextRounds());
            
            Assert.Equal("The game isn't started", ex.Message);
        }
    }
}