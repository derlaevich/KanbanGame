using System;
using KanbanGame.DomainModel.Game.Emuns;
using KanbanGame.DomainModel.Game.Entities;
using KanbanGame.DomainModel.Game.Tests.Dsl;
using Xunit;

namespace KanbanGame.DomainModel.Game.Tests.Entities
{
    public class TiketShould
    {
        [Fact]
        public void CreateInstanceWithIdWhichIsNotEqualEmptyGuid_WhenUsingDefaultConstructor()
        {
            var ticket = Create
                .Tiket
                .Please();
            
            Assert.NotEqual(Guid.Empty, ticket.Id);
        }

        [Fact]
        public void CreateInstanceWithActiveStatus()
        {
            var ticket = Create
                .Tiket
                .Please();
            
            Assert.Equal(TiketStatus.Active, ticket.Status);
        }

        [Fact]
        public void ChangeStatusToBlock_WhenCallBlock()
        {
            var ticket = Create
                .Tiket
                .Please();
            
            ticket.Block();
            
            Assert.Equal(TiketStatus.Block, ticket.Status);
        }

        [Fact]
        public void ChangeStatusToActive_WhenCallUnblock()
        {
            var ticket = Create
                .Tiket
                .Please();
            
            ticket.Unblock();
            
            Assert.Equal(TiketStatus.Active, ticket.Status);
        }
    }
}