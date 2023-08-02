namespace Corujasdev.Flowfunc.Domain.Common
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
    }

    public static class EntityExtensions
    {
        public static IEnumerable<T> Active<T>(this IEnumerable<T> query) where T : IEntity
            => query.Where(d => !d.DateDeleted.HasValue);
    }
}
