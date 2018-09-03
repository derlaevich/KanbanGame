using System;
using System.Collections.Generic;
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
        
        [Fact]
        public void ThrowException_IfPassCollectionIsEmpty()
        {
            var obj = new List<int>();
            
            var ex = Assert.Throws<ArgumentException>(() => Guard.ArgumentNotNullOrEmpty(nameof(obj), obj));

            Assert.Equal("obj", ex.ParamName);
            Assert.Contains("Argument was empty", ex.Message);
        }
        
        [Fact]
        public void ThrowException_IfPassCollectionIsNull()
        {
            List<int> obj = null;
            
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNullOrEmpty(nameof(obj), obj));

            Assert.Equal("obj", ex.ParamName);
        }
    }
}