using System;
using System.Collections.Generic;
using System.Linq;

namespace KanbanGame.DomainModel
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        protected abstract IEnumerable<object> GetAttributesToIncludeInEqualityCheck();

        public override bool Equals(object obj) => base.Equals(obj as T);

        public bool Equals(T obj)
        {
            if (obj == null)
            {
                return false;
            }

            return GetAttributesToIncludeInEqualityCheck()
                .SequenceEqual(obj.GetAttributesToIncludeInEqualityCheck());
        }

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right) => Equals(left, right);

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right) => !(left == right);

        public override int GetHashCode()
        {
            var hash = 21;
            var attributesToIncludeInEqualityCheck = GetAttributesToIncludeInEqualityCheck();
            foreach (var obj in attributesToIncludeInEqualityCheck)
            {
                hash = hash * 47 + (obj == null ? 0 : obj.GetHashCode());
            }
            
            return hash;
        }
    }
}
