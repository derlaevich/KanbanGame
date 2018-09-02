using System;
using KanbanGame.DomainModel.Game.Entities;
using Xunit;

namespace KanbanGame.DomainModel.Game.Tests.Entities
{
    public class PlayerShould
    {
        [Fact]
        public void CreateInstanceWithIdWhichIsNotEqualEmptyGuid_WhenUsingDefaultConstructor()
        {
            var player = new Player();
            
            Assert.NotEqual(Guid.Empty, player.Id);
        }
    }
}