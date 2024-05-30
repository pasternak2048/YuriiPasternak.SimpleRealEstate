namespace YuriiPasternak.SimpleRealEstate.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public Guid CreatedById { get; set; }

        public DateTimeOffset? ModifiedAt { get; set; }
        public Guid? ModifiedById { get; set; }
    }
}
