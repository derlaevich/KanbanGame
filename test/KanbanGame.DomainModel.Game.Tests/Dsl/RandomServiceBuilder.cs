using KanbanGame.DomainModel.Game.Interfaces;
using Moq;

namespace KanbanGame.DomainModel.Game.Tests.Dsl
{
    internal class RandomServiceBuilder
    {
        private int _result { get; set; } 

        public RandomServiceBuilder()
        {
            _result = 0;
        }

        public RandomServiceBuilder WithResult(int result)
        {
            _result = result;

            return this;
        }

        public IRandomService Please()
        {
            var randomServiceMock = new Mock<IRandomService>();
            randomServiceMock
                .Setup(rs => rs.GetRanodm(It.IsAny<int>()))
                .Returns(_result);

            return randomServiceMock.Object;
        }
    }
}