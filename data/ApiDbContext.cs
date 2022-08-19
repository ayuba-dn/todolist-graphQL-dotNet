using System;

using Microsoft.EntityFrameworkCore;
using TodoListQL.models;

namespace TodoListQL.data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<ItemData>Items { get;set;}
        public virtual DbSet<ItemList>Lists { get;set;}

        public virtual DbSet<ItemList>ItemList { get;set;}
        public virtual DbSet<ItemData>ItemData { get;set;}

        public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options){
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemData>(entity =>{
                entity.HasOne(d=>d.ItemList)
                        .WithMany(p=>p.ItemDatas)
                        .HasForeignKey(d=>d.ListId)
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_ItemData_ItemList");
            });
        }

    }
}
