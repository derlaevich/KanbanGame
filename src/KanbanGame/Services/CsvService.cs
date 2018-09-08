using System.Collections.Generic;
using KanbanGame.DomainModel.Reports;
using ServiceStack.Text;
using System.IO;

namespace KanbanGame.Services
{
    public class CsvService
    {
        public void Save(List<GameResult> items)
        {
            var csvText = CsvSerializer.SerializeToString(items);
            File.WriteAllText("GamesResult.csv", csvText);
        }
    }
}