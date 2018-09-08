using System;
using System.Collections.Generic;
using KanbanGame.DomainModel.Game.Entities;
using KanbanGame.DomainModel.Game.Factories;
using KanbanGame.DomainModel.Reports;
using KanbanGame.Models;
using KanbanGame.Repositories;
using KanbanGame.Services;

namespace KanbanGame
{
    class Program
    {
        private static readonly GameResultRepository gameResultRepository = new GameResultRepository();
        private static readonly CsvService csvService = new CsvService();
        
        static void Main(string[] args)
        {
            const int numberOfGames = 100;
                
            for (var i = 0; i < numberOfGames; i++)
            {
                var gameRules = GameRules.Create();
                var game = GameFactory.Create(gameRules.NumberOfPlayers, gameRules.NumberOfRounds, gameRules.NumberOfPlayers);
                
                PlayGame(game);
                
                var gameResult = new GameResult
                (
                    gameId: game.Id,
                    numberOfPlayers: gameRules.NumberOfPlayers,
                    wipLimit: gameRules.WipLimit,
                    numberOfDoneTickets: game.GetResult()
                );
                
                gameResultRepository.Save(gameResult);
            }

            var resultList = gameResultRepository.Get();
            csvService.Save(resultList); 
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
