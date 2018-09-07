using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KanbanGame.Core;
using KanbanGame.DomainModel.Game.Emuns;
using KanbanGame.DomainModel.Game.ValueObjects;

namespace KanbanGame.DomainModel.Game.Entities
{
    public class FeatureBanGame
    {
        private readonly List<Player> _players;
        private readonly int _numberOfRounds;
        private readonly Desk _desk;
        private IEnumerator _roundsEnumerator;
        private GameStatus _status;
        private Round _currentRound;

        public FeatureBanGame(List<Player> players, Desk desk, int numberOfRounds)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(players), players);
            Guard.ArgumentNotNull(nameof(desk), desk);
            Guard.ArgumentValid(nameof(numberOfRounds), "Argument must be greater than 0", numberOfRounds > 0);

            _players = players;
            _numberOfRounds = numberOfRounds;
            _status = GameStatus.Stopped;
            _desk = desk;
        }

        public void StartGame()
        {
            _roundsEnumerator = Enumerable.Range(0, _numberOfRounds).GetEnumerator();
            
            _status = GameStatus.Started;
        }

        public bool MoveNextRounds()
        {
            if (_status != GameStatus.Started)
            {
                throw new InvalidOperationException("The game isn't started");
            }

            var nextRoundIsAvailable = _roundsEnumerator.MoveNext();
            if (!nextRoundIsAvailable)
            {
                _status = GameStatus.Stopped;
                return nextRoundIsAvailable;
            }

            _currentRound = new Round(_players, _desk);
            return nextRoundIsAvailable;
        }

        public void PlayRound()
        {
            if (_currentRound == null)
            {
                throw new InvalidOperationException("No active round");
            }
            
            _currentRound.Play();

            _currentRound = null;
        }

        public int GetResult()
        {
            return _desk.Done.Count();
        }
    }
}