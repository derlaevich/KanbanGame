using Xunit;

namespace KanbanGame.DomainModel.Tests
{
    public class EntityShould
    {
        [Fact]
        public void CreateInstanceWhithDefaultId_WhenUsingDefaultConstructor()
        {
            var entity = new Entity<int>();

            Assert.Equal(default(int), entity.Id);
        }

        [Fact]
        public void CreateInstanceWithSpecificId_WhenUsingConstructor()
        {
            var entity = new Entity<int>(1);

            Assert.Equal(1, entity.Id);
        }

        [Fact]
        public void CalculateSameHashCode_IfInstancesHaveIdenticalId()
        {
            var entityFirst = new Entity<int>(1);
            var entitySecond = new Entity<int>(1);

            var hashCodeFirst = entityFirst.GetHashCode();
            var hashCodeSecond =  entitySecond.GetHashCode();

            Assert.Equal(hashCodeFirst, hashCodeSecond);
        }

        [Fact]
        public void CalculateDifferentHashCode_IfInstancesHaveDifferentId()
        {
            var entityFirst = new Entity<int>(1);
            var entitySecond = new Entity<int>(2);

            var hashCodeFirst = entityFirst.GetHashCode();
            var hashCodeSecond = entitySecond.GetHashCode();

            Assert.NotEqual(hashCodeFirst, hashCodeSecond);
        }

        [Fact]
        public void EqualWithDifferentInstance_IfEntitiesHaveIdenticalId()
        {
            var entityFirst = new Entity<int>(1);
            var entitySecond = new Entity<int>(1);

            var areEqual = entityFirst.Equals(entitySecond);

            Assert.True(areEqual);
        }
    }
}

