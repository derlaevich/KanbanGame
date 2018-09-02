using System;
using Xunit;

namespace KanbanGame.Core.Tests
{
    public class GuardShould
    {
        [Fact]
        public void ThrowException_IfPassObjectIsNull()
        {
            object obj = null;
            
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull(nameof(obj), obj));

            Assert.Equal("obj", ex.ParamName);
        }
    }
}