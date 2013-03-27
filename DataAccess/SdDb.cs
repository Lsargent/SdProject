﻿using System.Data.Entity.ModelConfiguration.Conventions;
using Logic;
using System.Data.Entity;

namespace DataAccess
{
    public class SdDb : DbContext 
    {       
        public SdDb() : base("name = " + AppConfig.GetActiveConnectionString()) {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BaseComponent> Components { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<EntityChange> EntityChanges { get; set; }
        public DbSet<Friendship> Friends { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Image> Images { get; set; }        
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageThread> MessageThreads { get; set; }
        public DbSet<OwnedEntity> OwnedEntities { get; set; }
        public DbSet<OwnedEntityChange> OwnedEntityChanges { get; set; } 
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public class DatabaseInitializer : CreateDatabaseIfNotExists<SdDb> {
            protected override void Seed(SdDb context) {
                base.Seed(context);
                var database = context.Database;
                //Create Unique fields that are not keys
                //Users Table
                database.ExecuteSqlCommand("ALTER TABLE USERS " +
                                           "ADD Constraint UC_UserName UNIQUE (UserName)");
                database.ExecuteSqlCommand("ALTER TABLE USERS " +
                                           "ADD Constraint UC_Email UNIQUE (Email)");
            }
        }
    }
}
