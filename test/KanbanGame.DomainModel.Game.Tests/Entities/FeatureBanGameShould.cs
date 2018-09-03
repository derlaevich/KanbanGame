using System;
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

            var playedRounds = 0;
            while (game.NextRound())
            {
                playedRounds++;
            }
            
            Assert.Equal(playedRounds, 5);
        }
    }
}