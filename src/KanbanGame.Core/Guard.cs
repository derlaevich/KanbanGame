using System;

namespace KanbanGame.Core
{
    public static class Guard
    {
        public static void ArgumentNotNull(string argName, object argValue)
        {
            if (argValue == null)
                throw new ArgumentNullException(argName);
        }
    }
}