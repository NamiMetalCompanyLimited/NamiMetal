//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
//using System;
//using System.Data;
//using Volo.Abp.Auditing;
//using Volo.Abp.EntityFrameworkCore.Modeling;

//namespace NamiMetal.EntityFrameworkCore
//{
//    public static class EntityTypeBuilderExtension
//    {
//        private static readonly ValueConverter<DateTime, DateTimeOffset> DateTimeConverter = new ValueConverter<DateTime, DateTimeOffset>
//         (
//             convertToProviderExpression: v => (v.Kind == DateTimeKind.Utc) ? new DateTimeOffset(v, TimeSpan.Zero) : new DateTimeOffset(v),
//             convertFromProviderExpression: v => v.UtcDateTime
//         );

//        private static readonly ValueConverter<DateTime?, DateTimeOffset?> NullableDateTimeConverter = new ValueConverter<DateTime?, DateTimeOffset?>
//        (
//            convertToProviderExpression: v => v.HasValue ? new DateTimeOffset(v.Value) : (DateTimeOffset?)null,
//            convertFromProviderExpression: v => v.HasValue ? v.Value.UtcDateTime : (DateTime?)null
//        );

//        public static void ConfigureByConvention(this EntityTypeBuilder b)
//        {
//            AbpEntityTypeBuilderExtensions.ConfigureByConvention(b);
//            //TryConfigureActiveData(b);
//            TryConfigureCreationTime(b);
//            TryConfigureLastModificationTime(b);
//            TryConfigureDeletionTime(b);
//        }

//        //public static void TryConfigureActiveData(this EntityTypeBuilder b)
//        //{
//        //    if (b.Metadata.ClrType.IsAssignableTo<IIsActive>())
//        //    {
//        //        b.Property(nameof(IIsActive.IsActive))
//        //            .IsRequired()
//        //            .HasDefaultValue(false)
//        //            .HasColumnName(nameof(IIsActive.IsActive));
//        //    }
//        //}

//        public static void TryConfigureCreationTime(this EntityTypeBuilder b)
//        {
//            if (b.Metadata.ClrType.IsAssignableTo<IHasCreationTime>())
//            {
//                b.Property(nameof(IHasCreationTime.CreationTime))
//                    .IsRequired()
//                    .HasColumnName(nameof(IHasCreationTime.CreationTime))
//                    .HasColumnType(nameof(SqlDbType.DateTimeOffset))
//                    .HasDefaultValueSql("GETDATE()")
//                    .HasConversion(DateTimeConverter);
//            }
//        }

//        public static void TryConfigureLastModificationTime(this EntityTypeBuilder b)
//        {
//            if (b.Metadata.ClrType.IsAssignableTo<IHasModificationTime>())
//            {
//                b.Property(nameof(IHasModificationTime.LastModificationTime))
//                    .IsRequired(false)
//                    .HasColumnName(nameof(IHasModificationTime.LastModificationTime))
//                    .HasColumnType(nameof(SqlDbType.DateTimeOffset))
//                    .HasConversion(NullableDateTimeConverter);
//            }
//        }

//        public static void TryConfigureDeletionTime(this EntityTypeBuilder b)
//        {
//            if (b.Metadata.ClrType.IsAssignableTo<IHasDeletionTime>())
//            {
//                b.TryConfigureSoftDelete();

//                b.Property(nameof(IHasDeletionTime.DeletionTime))
//                    .IsRequired(false)
//                    .HasColumnName(nameof(IHasDeletionTime.DeletionTime))
//                    .HasColumnType(nameof(SqlDbType.DateTimeOffset))
//                    .HasConversion(NullableDateTimeConverter);
//            }
//        }
//        #region Tienvv8 add 
//        //private static readonly ValueConverter<DateTime?, DateTime?> NullableDateTimeConverter2 = new ValueConverter<DateTime?, DateTime?>
//        //(
//        //    convertToProviderExpression: v => v.HasValue ? new DateTimeOffset(v.Value) : (DateTimeOffset?)null,
//        //    convertFromProviderExpression: v => v.HasValue ? v.Value.UtcDateTime : (DateTime?)null
//        //);
//        public static void ConfigureByConvention2(this EntityTypeBuilder b)
//        {
//            AbpEntityTypeBuilderExtensions.ConfigureByConvention(b);
//            //TryConfigureActiveData(b);
//            TryConfigureCreationTime2(b);
//            TryConfigureLastModificationTime2(b);
//            TryConfigureDeletionTime2(b);
//        }


//        public static void TryConfigureCreationTime2(this EntityTypeBuilder b)
//        {
//            if (b.Metadata.ClrType.IsAssignableTo<IHasCreationTime>())
//            {
//                b.Property(nameof(IHasCreationTime.CreationTime))
//                    .IsRequired()
//                    .HasColumnName(nameof(IHasCreationTime.CreationTime))
//                    .HasColumnType(nameof(SqlDbType.DateTime2))
//                    .HasDefaultValueSql("GETDATE()");
//            }
//        }

//        public static void TryConfigureLastModificationTime2(this EntityTypeBuilder b)
//        {
//            if (b.Metadata.ClrType.IsAssignableTo<IHasModificationTime>())
//            {
//                b.Property(nameof(IHasModificationTime.LastModificationTime))
//                    .IsRequired(false)
//                    .HasColumnName(nameof(IHasModificationTime.LastModificationTime))
//                    .HasColumnType(nameof(SqlDbType.DateTime2));
//            }
//        }

//        public static void TryConfigureDeletionTime2(this EntityTypeBuilder b)
//        {
//            if (b.Metadata.ClrType.IsAssignableTo<IHasDeletionTime>())
//            {
//                b.TryConfigureSoftDelete();

//                b.Property(nameof(IHasDeletionTime.DeletionTime))
//                    .IsRequired(false)
//                    .HasColumnName(nameof(IHasDeletionTime.DeletionTime))
//                    .HasColumnType(nameof(SqlDbType.DateTime2));
//            }
//        }
//        #endregion
//    }
//}
