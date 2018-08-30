using KanbanGame.DomainModel.Game.Services;
using System.Collections.Generic;
using Xunit;

namespace KanbanGame.DomainModel.Game.Tests
{
    public class RandomServiceShould
    {
        [Fact]
        public void GenerateRandomValueWithinSpecifiedRange()
        {
            var randomService = new RandomService();
            var upperBound = 2;

            var ranodmValues = new List<int>();
            for (var i = 0; i < 100; i++)
            {
                ranodmValues.Add(randomService.GetRanodm(upperBound));
            }

            Assert.All(ranodmValues, item => Assert.InRange(item, low: 0, high: 1));
        }
    }
}
