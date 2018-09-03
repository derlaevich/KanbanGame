using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KanbanGame.Core;

namespace KanbanGame.DomainModel.Game.Entities
{
    public class FeatureBanGame
    {
        private List<Player> _players;
        private int _numberOfRounds;
        private IEnumerator _roundsEnumerator;

        public FeatureBanGame(List<Player> players, int numberOfRounds)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(players), players);

            var numberOfRoundsIsValid = numberOfRounds > 0;
            Guard.ArgumentValid(nameof(numberOfRounds), "Argument must be greater than 0", numberOfRoundsIsValid);

            _players = players;
            _numberOfRounds = numberOfRounds;
        }

        public void StartGame()
        {
            var _roundsEnumerator = Enumerable.Range(0, _numberOfRounds).GetEnumerator();
        }

        public bool NextRound()
        {
            var hasNextRound = _roundsEnumerator.MoveNext();
            if (hasNextRound)
            {
                return hasNextRound;
            }

            return hasNextRound;
        }
    }
}