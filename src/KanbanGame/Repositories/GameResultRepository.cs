using System.Collections.Generic;
using System.Collections.Specialized;
using KanbanGame.DomainModel.Reports;
using KanbanGame.DomainModel.Reports.Interface;

namespace KanbanGame.Repositories
{
    public class GameResultRepository : IGameResultRepository
    {
        private readonly List<GameResult> items = new List<GameResult>();
            
        public void Save(GameResult gameResult)
        {
            items.Add(gameResult);
        }

        public List<GameResult> Get()
        {
            return items;
        }
    }
}