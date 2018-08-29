
namespace KanbanGame.DomainModel
{
    public class Entity<T>
    {
        public T Id { get; private set; }

        public Entity()
        {
            Id = default(T);
        }

        public Entity(T id)
        {
            Id = id;
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public bool Equals(Entity<T> obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            if (base.Equals(obj))
                return true;

            return Id.Equals(obj.Id);
        }
    }
}
