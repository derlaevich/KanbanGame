using System;
using System.Collections;

namespace KanbanGame.Core
{
    public static class Guard
    {
        public static void ArgumentNotNull(string argName, object argValue)
        {
            if (argValue == null)
                throw new ArgumentNullException(argName);
        }
        
        public static void ArgumentNotNullOrEmpty(string argName, IEnumerable argValue)
        {
            ArgumentNotNull(argName, argValue);
            if (!argValue.GetEnumerator().MoveNext())
                throw new ArgumentException("Argument was empty", nameof(argValue));
        }
    }
}