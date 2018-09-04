
namespace KanbanGame.DomainModel.Game.Tests.Dsl
{
    internal class Create
    {
        public static RandomServiceBuilder RandomService => new RandomServiceBuilder();

        public static FeatureBanGameBuilder FeatureBanGame = new FeatureBanGameBuilder();
        
        public  static TicketBuilder Tiket = new TicketBuilder();
    }
}
