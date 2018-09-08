using System;
using System.Collections.Generic;
using KanbanGame.Core;
using KanbanGame.DomainModel.Game.Emuns;
using KanbanGame.DomainModel.Game.Entities;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("KanbanGame.DomainModel.Game.Tests")]
[assembly:InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace KanbanGame.DomainModel.Game.ValueObjects
{
    public class Round : ValueObject
    {
        private readonly List<Player> _players;
        private readonly Desk _desk;
       
        public Round(List<Player> players, Desk desk)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(desk), players);
            Guard.ArgumentNotNull(nameof(desk), desk);
            
            _players = players;
            _desk = desk;
        }

        public void Play()
        {
            foreach (var player in _players)
            {
                var coin = FlipCoin();

                switch (coin.Side)
                {
                    case SideOfCoin.Tails:
                        DoTailsActions(player);
                        return;
                    case SideOfCoin.Heads:
                        DoHeadsActions(player);
                        return;
                    default:
                        throw new ArgumentOutOfRangeException();
                } 
            }
        }

        internal virtual Coin FlipCoin()
        {
            return Coin.Flip();
        }

        internal virtual void DoTailsActions(Player player)
        {
            if (_desk.TryGetOpenAndActiveTicket(player.Id, out var ticket))
            {
                try
                {
                    _desk.MoveToNextColumn(ticket);
                    return;
                }
                catch (InvalidOperationException)
                { }
            }

            if (_desk.TryGetOpenAndBlockTicket(player.Id, out ticket))
            {
                ticket.Unblock();
                return;
            }

            if (_desk.TryGetTicketFromBacklog(player.Id, out ticket))
            {
                try
                {
                    _desk.MoveToNextColumn(ticket);
                }
                catch (InvalidOperationException)
                { }
            }
        }

        internal virtual void DoHeadsActions(Player player)
        {
            if (_desk.TryGetOpenAndActiveTicket(player.Id, out var ticket))
            {
                ticket.Block();
                return;
            }
            
            if (_desk.TryGetTicketFromBacklog(player.Id, out ticket))
            {
                ticket.Unblock();
            }
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _players;
            yield return _desk;
        }
    }
}