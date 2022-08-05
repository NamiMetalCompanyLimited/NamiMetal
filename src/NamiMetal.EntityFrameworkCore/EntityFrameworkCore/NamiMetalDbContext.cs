using Microsoft.EntityFrameworkCore;
using NamiMetal.Categories;
using NamiMetal.Collections;
using NamiMetal.Enums;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace NamiMetal.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class NamiMetalDbContext :
    AbpDbContext<NamiMetalDbContext>
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Category> Categories { get; set; }
    public DbSet<Collection> Collections { get; set; }

    public NamiMetalDbContext(DbContextOptions<NamiMetalDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(NamiMetalConsts.DbTablePrefix + "YourEntities", NamiMetalConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<Category>(e =>
        {
            e.ToTable(NamiMetalConsts.DbTablePrefix + nameof(Category), NamiMetalConsts.DbSchema);
            e.ConfigureByConvention();
            e.Property<string>(nameof(Category.Name)).IsRequired().HasMaxLength(100);
            e.Property<string>(nameof(Category.Description)).HasMaxLength(250);
            //e.Property<bool>(nameof(Category.Active)).HasMaxLength(50);
            //e.Property<Guid>(nameof(Category.CreatorId));
            //e.Property<DateTime>(nameof(Category.CreationTime));
            //e.Property<Guid>(nameof(Category.LastModifierId));
            //e.Property<DateTime>(nameof(Category.LastModificationTime));
            //e.Property<bool>(nameof(Category.IsDeleted));
            //e.Property<Guid>(nameof(Category.DeleterId));
            //e.Property<DateTime>(nameof(Category.DeletionTime));
        });

        builder.Entity<Collection>(e =>
        {
            e.ToTable(NamiMetalConsts.DbTablePrefix + nameof(Collection), NamiMetalConsts.DbSchema);
            e.ConfigureByConvention();
            e.Property<string>(nameof(Collection.Name)).IsRequired().HasMaxLength(100);
            e.Property<string>(nameof(Collection.Description)).HasMaxLength(250);
            //e.Property<bool>(nameof(Collection.Active)).HasMaxLength(50);
        });
    }
}
