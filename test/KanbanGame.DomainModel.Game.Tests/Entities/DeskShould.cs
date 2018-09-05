using System;
using KanbanGame.DomainModel.Game.Tests.Dsl;
using Xunit;

namespace KanbanGame.DomainModel.Game.Tests.Entities
{
    public class DeskShould
    {
        [Fact]
        public void CreateInstanceWithIdWhichIsNotEqualEmptyGuid_WhenUsingDefaultConstructor()
        {
            var desk = Create
                .Desk
                .Please();
            
            Assert.NotEqual(Guid.Empty, desk.Id);
        }

        [Fact]
        public void ThrowException_WhenTicketsIsNull()
        {
            var desk = Create
                .Desk
                .WithTickets(null);
            
            var ex = Assert.Throws<ArgumentNullException>(() => desk.Please());

            Assert.Equal("tickets", ex.ParamName);
        }
    }
}