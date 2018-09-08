using System;
using System.Collections.Generic;
using KanbanGame.DomainModel.Game.Entities;
using KanbanGame.DomainModel.Game.ValueObjects;
using Moq;

namespace KanbanGame.DomainModel.Game.Tests.Dsl
{
    public class RoundBuilder
    {
        private List<Player> _player = new List<Player>() { new Player() };
        private Desk _desk = new Desk(new List<Ticket> { new Ticket(Guid.NewGuid()) });
        private Coin _coin = null;

        public Round Please()
        {
            return new Round(_player, _desk);
        }

        public RoundBuilder WithCoin(Coin coin)
        {
            _coin = coin;

            return this;
        }

        public Mock<Round> PleaseMock()
        {
            var roundMock = new Mock<Round>(_player, _desk);

            if (_coin != null)
            {
                roundMock
                    .Setup(round => round.FlipCoin())
                    .Returns(_coin);
            }

            return roundMock;
        }
    }
}