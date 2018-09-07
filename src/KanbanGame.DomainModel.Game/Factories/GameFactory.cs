using System.Collections.Generic;
using System.Linq;
using KanbanGame.DomainModel.Game.Entities;

namespace KanbanGame.DomainModel.Game.Factories
{
    public class GameFactory
    {
        private static readonly int _ticketCountPerPlayer = 1000; 
        
        public static FeatureBanGame Create(int playerCount, int numberOfRounds, int? wipLimit)
        {
            var players = Enumerable
                .Range(0, playerCount)
                .Select(i => new Player())
                .ToList();
            
            var tickets = new List<Ticket>();
            foreach (var player in players)
            {
                var playerTickets = Enumerable
                    .Range(0, _ticketCountPerPlayer)
                    .Select(i => new Ticket(player.Id))
                    .ToList();
                tickets.AddRange(playerTickets);
            }
            
            var desk = new Desk(tickets, wipLimit);
            
            return new FeatureBanGame(players, desk, numberOfRounds);
        }
    }
}