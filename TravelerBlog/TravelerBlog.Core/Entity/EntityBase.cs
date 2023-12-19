namespace TravelerBlog.Core.Entity
{
    public abstract class EntityBase
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual bool IsActive { get; set; } = true;
        public virtual bool IsDeleted { get; set; } = false;
        public virtual string Description { get; set; }

    }
}
