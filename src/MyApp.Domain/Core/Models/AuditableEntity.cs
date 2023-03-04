namespace MyApp.Domain.Core.Models
{
    public class AuditableEntity : BaseEntity
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
        public string? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; } = DateTimeOffset.Now;
    }
}