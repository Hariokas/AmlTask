using Microsoft.EntityFrameworkCore;
class NotificationApiDb : DbContext
{
    public NotificationApiDb(DbContextOptions<NotificationApiDb> options) : base(options) { }

    public DbSet<Notification> Notifications => Set<Notification>();
}