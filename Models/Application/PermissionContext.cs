using System;
using System.Data.Entity;
using System.Linq;
using EFSecondLevelCache;
using Models.Entity;
using Models.Migrations;
using static System.Data.Entity.Core.Objects.ObjectContext;

namespace Models.Application
{
    public class PermissionContext : DbContext
    {
        public PermissionContext() : base("name=PermissionContext")
        {
            Configuration.AutoDetectChangesEnabled = false; //�ر��Զ����ٶ�������Ա仯
            Configuration.LazyLoadingEnabled = false; //�ر��ӳټ���
            Configuration.ProxyCreationEnabled = false; //�رմ�����
            Configuration.ValidateOnSaveEnabled = false; //�رձ���ʱ��ʵ����֤
            Configuration.UseDatabaseNullSemantics = true; //�ر����ݿ�null�Ƚ���Ϊ
            Database.CreateIfNotExists();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PermissionContext, Configuration>());
            Database.Log = Console.WriteLine;
        }

        public virtual DbSet<Function> Function { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }
        public virtual DbSet<UserGroupPermission> UserGroupPermission { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserPermission> UserPermission { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Permission>().HasMany(e => e.Function).WithRequired(e => e.Permission).WillCascadeOnDelete(false);

            modelBuilder.Entity<Permission>().HasMany(e => e.Role).WithMany(e => e.Permission).Map(m => m.ToTable("RolePermission"));

            modelBuilder.Entity<Role>().HasMany(e => e.UserGroupPermission).WithRequired(e => e.Role).WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>().HasMany(e => e.UserInfo).WithMany(e => e.Role).Map(m => m.ToTable("UserInfoRole"));

            modelBuilder.Entity<UserGroup>().HasMany(e => e.UserGroupPermission).WithRequired(e => e.UserGroup).WillCascadeOnDelete(false);

            modelBuilder.Entity<UserGroup>().HasMany(e => e.UserInfo).WithMany(e => e.UserGroup).Map(m => m.ToTable("UserInfoUserGroup"));
        }

        //��д SaveChanges
        public override int SaveChanges()
        {
            return SaveAllChanges();
        }

        public int SaveAllChanges(bool invalidateCacheDependencies = true)
        {
            var changedEntityNames = GetChangedEntityNames();
            var result = base.SaveChanges();
            if (invalidateCacheDependencies)
            {
                new EFCacheServiceProvider().InvalidateCacheDependencies(changedEntityNames);
            }
            return result;
        }

        //�޸ġ�ɾ�����������ʱ����ʧЧ
        private string[] GetChangedEntityNames()
        {
            return ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted).Select(x => GetObjectType(x.Entity.GetType()).FullName).Distinct().ToArray();
        }
    }
}