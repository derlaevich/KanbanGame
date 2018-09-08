using System.Collections.Generic;

namespace KanbanGame.DomainModel.Reports.Interface
{
    public interface IGameResultRepository
    {
        void Save(GameResult gameResult);
        List<GameResult> Get();
    }
}