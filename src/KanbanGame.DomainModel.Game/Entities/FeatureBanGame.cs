using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KanbanGame.Core;
using KanbanGame.DomainModel.Game.Emuns;

namespace KanbanGame.DomainModel.Game.Entities
{
    public class FeatureBanGame
    {
        private readonly List<Player> _players;
        private readonly int _numberOfRounds;
        private IEnumerator _roundsEnumerator;
        private GameStatus _status;

        public FeatureBanGame(List<Player> players, int numberOfRounds)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(players), players);

            var numberOfRoundsIsValid = numberOfRounds > 0;
            Guard.ArgumentValid(nameof(numberOfRounds), "Argument must be greater than 0", numberOfRoundsIsValid);

            _players = players;
            _numberOfRounds = numberOfRounds;
            _status = GameStatus.Stopped;
        }

        public void StartGame()
        {
            _roundsEnumerator = Enumerable.Range(0, _numberOfRounds).GetEnumerator();
            
            _status = GameStatus.Started;
        }

        public bool MoveNextRounds()
        {
            if (_status == GameStatus.Stopped)
            {
                throw new InvalidOperationException("The game isn't started");
            }

            return _roundsEnumerator.MoveNext();
        }
    }
}