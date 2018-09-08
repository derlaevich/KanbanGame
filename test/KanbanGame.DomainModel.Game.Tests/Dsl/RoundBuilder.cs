using System;
using System.Collections.Generic;
using KanbanGame.DomainModel.Game.Entities;
using KanbanGame.DomainModel.Game.ValueObjects;
using Moq;

namespace KanbanGame.DomainModel.Game.Tests.Dsl
{
    public class RoundBuilder
    {
        private List<Player> _players = new List<Player> { new Player() };
        private Desk _desk = new Desk(new List<Ticket> { new Ticket(Guid.NewGuid()) });
        private Coin _coin = null;

        public RoundBuilder WithCoin(Coin coin)
        {
            _coin = coin;

            return this;
        }
        
        public RoundBuilder WithDesk(Desk desk)
        {
            _desk = desk;

            return this;
        }
        
        public Round Please()
        {
            return new Round(_players, _desk);
        }

        public Mock<Round> PleaseMock()
        {
            var roundMock = new Mock<Round>(_players, _desk);

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