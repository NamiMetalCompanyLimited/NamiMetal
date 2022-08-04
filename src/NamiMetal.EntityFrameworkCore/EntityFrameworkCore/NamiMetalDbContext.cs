using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace NamiMetal.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class NamiMetalDbContext :
    AbpDbContext<NamiMetalDbContext>
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

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
    }
}
