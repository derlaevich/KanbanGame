
namespace KanbanGame.DomainModel.Game.Tests.Dsl
{
    internal class Create
    {
        public static RandomServiceBuilder RandomService => new RandomServiceBuilder();

        public static FeatureBanGameBuilder FeatureBanGame => new FeatureBanGameBuilder();
        
        public static TicketBuilder Ticket => new TicketBuilder();
        
        public static DeskBuilder Desk => new DeskBuilder();
        
        public static ColumnBuilder Column => new ColumnBuilder();
        
        public static RoundBuilder Round => new RoundBuilder();
    }
}
