using Microsoft.EntityFrameworkCore;
using NamiMetal.ProductCategories;
using NamiMetal.Collections;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace NamiMetal.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class NamiMetalDbContext :
    AbpDbContext<NamiMetalDbContext>
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<Attributes.Attribute> Attributes { get; set; }
    public DbSet<AttributeOptions.AttributeOption> AttributeOptions { get; set; }

    public NamiMetalDbContext(DbContextOptions<NamiMetalDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ProductCategory>(e =>
        {
            e.ToTable(NamiMetalConsts.DbTablePrefix + nameof(ProductCategory), NamiMetalConsts.DbSchema);
            e.ConfigureByConvention();
            e.Property<string>(nameof(ProductCategory.Name)).IsRequired().HasMaxLength(100);
            e.Property<string>(nameof(ProductCategory.Description)).HasMaxLength(250);
            //e.Property<bool>(nameof(Category.Active)).HasMaxLength(50);
            //e.Property<Guid>(nameof(Category.CreatorId));
            //e.Property<DateTime>(nameof(Category.CreationTime));
            //e.Property<Guid>(nameof(Category.LastModifierId));
            //e.Property<DateTime>(nameof(Category.LastModificationTime));
            //e.Property<bool>(nameof(Category.IsDeleted));
            //e.Property<Guid>(nameof(Category.DeleterId));
            //e.Property<DateTime>(nameof(Category.DeletionTime));
            e.HasMany(d => d.Childrens)
            //.HasConstraintName("FK_ProductCategory_ProductCategory")
            ;

            e.Ignore(x => x.Parent);
            e.Ignore(x => x.Childrens);
        });

        builder.Entity<Collection>(e =>
        {
            e.ToTable(NamiMetalConsts.DbTablePrefix + nameof(Collection), NamiMetalConsts.DbSchema);
            e.ConfigureByConvention();
            e.Property(p => p.Name).IsRequired().HasMaxLength(250);
            e.Property(p => p.Description).HasMaxLength(250);
        });

        builder.Entity<Attributes.Attribute>(e =>
        {
            e.ToTable(NamiMetalConsts.DbTablePrefix + nameof(NamiMetal.Attributes.Attribute), NamiMetalConsts.DbSchema);
            e.ConfigureByConvention();
            e.Property(p => p.Name).IsRequired().HasMaxLength(100);
            e.Property(p => p.Description).HasMaxLength(250);
            //e.Ignore(c => c.Childrens);
        });

        builder.Entity<AttributeOptions.AttributeOption>(e =>
        {
            e.ToTable(NamiMetalConsts.DbTablePrefix + nameof(NamiMetal.AttributeOptions.AttributeOption), NamiMetalConsts.DbSchema);
            e.ConfigureByConvention();
            e.Property(p => p.Name).IsRequired().HasMaxLength(100);
            e.Property(p => p.Description).HasMaxLength(250);
            e.HasOne(c => c.Attribute)
                .WithMany(c => c.Childrens)
                .HasForeignKey(c => c.AttributeId);
            ;
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.EnableSensitiveDataLogging();
    }
}
