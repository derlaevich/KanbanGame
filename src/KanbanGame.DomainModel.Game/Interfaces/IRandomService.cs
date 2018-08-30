using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("KanbanGame.DomainModel.Game.Tests")]
namespace KanbanGame.DomainModel.Game.Interfaces
{
    internal interface IRandomService
    {
        int GetRanodm(int upperBound);
    }
}
