using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace NamiMetal.EntityFrameworkCore;

[DependsOn(
    typeof(NamiMetalDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
    )]
public class NamiMetalEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        NamiMetalEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<NamiMetalDbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities: true);
            options.Entity<Attributes.Attribute>(opts =>
            {
                opts.DefaultWithDetailsFunc = (
                q => q
                    .Include(e => e.Childrens)
                            //.ThenInclude(e => e.Attribute)
                );
            });
        });

        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also NamiMetalMigrationsDbContextFactory for EF Core tooling. */
            options.UseSqlServer();
        });
    }
}
