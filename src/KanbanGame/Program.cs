using System;
using KanbanGame.DomainModel.Game.Entities;
using KanbanGame.DomainModel.Game.Factories;
using KanbanGame.Models;

namespace KanbanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfGames = 100;

            for (var i = 0; i < numberOfGames; i++)
            {
                var gameRules = GameRules.Create();
                
                var game = GameFactory.Create(gameRules.NumberOfPlayers, gameRules.NumberOfRounds, gameRules.NumberOfPlayers);
                PlayGame(game);
                Console.WriteLine($"Game {i}: {game.GetResult()}");
            }
        }

        private static void PlayGame(FeatureBanGame game)
        {
            game.StartGame();
            while (game.MoveNextRounds())
            {
                game.PlayRound();
            }
        }
    }
}
